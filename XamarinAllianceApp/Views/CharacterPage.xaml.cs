using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAllianceApp.Models;

namespace XamarinAllianceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterPage : ContentPage
    {
        public Character _charac { get; set; }
        public CharacterPage()
        {
            InitializeComponent();         
           
        }
        public CharacterPage(Character character):this()
        {
            _charac = character;
            BindingContext = _charac;
        }

        
    }
}
