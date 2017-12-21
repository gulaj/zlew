using Starcounter;

namespace KitchenSink
{
    partial class ClientLocalStatePage : Json
    {
        protected override void OnData()
        {
            base.OnData();

            ClientLocalStatePage.PeopleElementJson person;
            person = this.People.Add();
            person.Name = "John Doe";

            person = this.People.Add();
            person.Name = "Jessica Doe";
        }
    }
}