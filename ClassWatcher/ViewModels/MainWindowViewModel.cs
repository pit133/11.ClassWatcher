using Avalonia.Rendering.Composition;
using ClassWatcher.UserObjects;
using DynamicData;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reflection;

namespace ClassWatcher.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
#pragma warning disable CA1822 // Mark members as static
        


        public object Object = new User
        {
            Id = 1,
            Name = "John Doe",
            Username = "johndoe",
            Email = "johndoe@example.com",
            Address = new Address
            {
                Street = "123 Street",
                Suite = "Apt 101",
                City = "Cityville",
                Zipcode = "12345",
                Geo = new Geo
                {
                    Lat = "40.7128",
                    Lng = "-74.0060"
                }
            },
            Phone = "123-456-7890",
            Website = "www.example.com",
            Company = new Company
            {
                Name = "Example Company",
                CatchPhrase = "Catchy phrase",
                Bs = "BS BS BS"
            }
        };

        private ObservableCollection<ClassNode> _objectPropertiesTree;

        public ObservableCollection<ClassNode> ObjectPropertiesTree
        {
            get => _objectPropertiesTree;
            set => this.RaiseAndSetIfChanged(ref _objectPropertiesTree, value);
        }

        public MainWindowViewModel()
        {
            ObjectPropertiesTree = new ObservableCollection<ClassNode>();
            ObservableCollection<ClassNode> userNode = new ObservableCollection<ClassNode>();
            ObjectPropertiesTree.Add(new ClassNode(Object.GetType().Name,"", userNode));
            MakeClassTree(Object,userNode);
            //int a = 5;
            
        }

        private void MakeClassTree(object obj, ObservableCollection<ClassNode> Node)
        {           
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();           

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj);
                //Console.WriteLine($"{property.Name}: {value}");

                if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    ObservableCollection<ClassNode> newNode = new ObservableCollection<ClassNode>();
                    Node.Add(new ClassNode(property.Name, "", newNode));
                    MakeClassTree(value, newNode); 
                }
                else
                {
                    Node.Add(new ClassNode(property.Name, value.ToString()));
                }
            }
        }


#pragma warning restore CA1822 // Mark members as static
    }
}