using Microsoft.Maui.Controls;
using mperugachiAC5.Models;
using System;

namespace mperugachiAC5.Views;

public partial class vPersona : ContentPage
{
    public vPersona()
    {
        InitializeComponent();
    }
    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.personRepo.AddNewPerson(txtName.Text);
        lblStatus.Text = App.personRepo.StatusMessage;
    }
    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        List<Persona> people = App.personRepo.getAllPeople();
        ListaPersona.ItemsSource = people;
        lblStatus.Text = App.personRepo.StatusMessage;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var tarea = button?.CommandParameter as Tarea;

        if (tarea != null)
        {
            //await Navigation.PushAsync(new EditarTareaPage(tarea));
        }
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        var tarea = ((Button)sender).CommandParameter as Tarea;
        //var button = sender as Button;
        //var tarea = button?.CommandParameter as Tarea;

        if (tarea != null)
        {
            if (BindingContext is MainViewModel viewModel)
            {
                viewModel.EliminarTarea(tarea);
            }
        }
    }
}