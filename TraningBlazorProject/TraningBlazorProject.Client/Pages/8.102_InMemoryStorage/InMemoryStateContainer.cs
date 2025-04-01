namespace TraningBlazorProject.Client.Pages._8._102_InMemoryStorage
{
        public class InMemoryStateContainer : IDisposable
        {
            private string? firstName;
            private string? lastName;


            public InMemoryStateContainer()
            {
                Console.WriteLine("InMemoryStateContainer Created...");
            }
            public string FirstName
            {
                get => firstName ?? string.Empty;
                set
                {
                    firstName = value;
                    NotifyStateChanged();
                }
            }
            public string LastName
            {
                get => lastName ?? string.Empty;
                set
                {
                    lastName = value;
                    NotifyStateChanged();
                }
            }

            public event Action? OnChange;

            public void Dispose()
            {
                Console.WriteLine("InMemoryStateContainer   ---->  Dispose...");
            }

            private void NotifyStateChanged()
            {
                OnChange?.Invoke();
            }

        }
    }
