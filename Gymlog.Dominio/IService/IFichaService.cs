﻿using Gymlog.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dominio.IService
{
    public interface IFichaService
    {
        public void CadastrarFicha(Ficha ficha);
        public void EditarFicha(Ficha ficha);
        public void ApagarFicha(int fichaID);
        public Ficha GetOneById(int fichaID);
        public IEnumerable<Ficha> GetAll();
    }
}
