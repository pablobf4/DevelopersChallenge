using PA.CampeonatoXadrez.Data.Repositorio;
using PA.CampeonatoXadrez.Dominio.Interface.Repository;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.CampeonatoXadrez.CrossCutting.IOC
{
   public class BootStrapper
    {
       public static void RegisterServices(Container container)
       {
           container.RegisterPerWebRequest<IJogadorRepository, JogadorRepositorio>();
           container.RegisterPerWebRequest<IPartidaRepository, PartidaRepositorio>();
           container.RegisterPerWebRequest<ICampeonatoRepository, CampeonatoRepositorio>();
       } 

    }
}
