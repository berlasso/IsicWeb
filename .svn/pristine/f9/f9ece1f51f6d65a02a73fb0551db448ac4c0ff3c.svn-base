using System;
using System.Collections.Generic;

namespace ISICWeb.Mappers
{
    public class Mapper<Model, ViewModel>
        where Model : class
        where ViewModel : class
    {
        public virtual ViewModel MapFromModel(Model model)
        {
            throw new System.NotImplementedException();
        }

        public virtual Model MapFromViewModel(ViewModel viewModel, Model model = null)
        {
            throw new System.NotImplementedException();
        }

        public List<ViewModel> MapFromModelList(ICollection<Model> modelList)
        {
            var result = new List<ViewModel>();

            foreach (var model in modelList)
            {
                try
                {
                    var viewModel = this.MapFromModel(model);
                    if (viewModel != null)
                    {
                        result.Add(viewModel);
                    }
                }
                catch (InvalidOperationException)
                {
                    //Si entró acá es porque hay una inconsistencia en los datos, por ejemplo, un id de clave foranea que no existe.
                    //En ese caso no se añadirá en la lista el objeto que tiró el error (ya que tiene mal cargados los datos)
                    continue;
                }
                catch (NullReferenceException e)
                {
                    //Si entró acá es porque hay una inconsistencia en los datos, por ejemplo, un id de clave foranea que no existe.
                    //En ese caso no se añadirá en la lista el objeto que tiró el error (ya que tiene mal cargados los datos)
                    continue;
                }
            }

            return result;
        }

        public List<Model> MapFromViewModelList(ICollection<ViewModel> viewModelList)
        {
            var result = new List<Model>();

            foreach (var viewModel in viewModelList)
            {
                result.Add(this.MapFromViewModel(viewModel));
            }

            return result;
        }
    }
}