

async function receiveRawData(data) {

    console.log("Receiving raw data...");

    console.log("Raw data received:", data);

    console.log("Raw data complete.");
}

async function receiveStreamAsArrayBuffer(streamRef) {

    console.log("Receiving full stream as ArrayBuffer...");

    const data = await streamRef.arrayBuffer();

    const text = new TextDecoder("utf-8").decode(data);

    console.log("Full data received as text:", text);

    console.log("End...receiveStreamAsArrayBuffer");

}



async function receiveStreamAsChunks(streamRef) {
    console.log("Receiving stream in chunks...");

    var stream = await streamRef.stream();

    var reader = stream.getReader();

    while (true) {

        const { done, value } = await reader.read();
        if (done) {
            console.log("-> Stream processing complete.")
            break;
        }

        const chunk = new TextDecoder("utf-8").decode(value);
        console.log("Chunk received:", chunk);
    }
}