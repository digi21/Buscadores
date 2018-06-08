﻿using System.Collections.Generic;
using Digi21.DigiNG.Plugin;
using System.Windows.Forms;
using Digi21.DigiNG.Entities;
using Digi21.Utilities;
using System.Linq;
using Digi21Search;

namespace Digi21.Search
{
    [LocalizableSearcher(typeof(MyResource), "BuscarLíneasPorCriterioName")]
    public class BuscarLíneasPorCriterio : ISearcher
    {
        private readonly FormularioBuscarLíneasCriterio form = new FormularioBuscarLíneasCriterio();
        public Form Form => form;

        public IEnumerable<Entity> Search(IEnumerable<Entity> entities)
        {
            if (!form.QueEsténCerradas) 
                return entities.OfType<ReadOnlyLine>().QueTenganElCódigoConComodín(form.Código);

            return from entidad in entities
                where entidad is ReadOnlyLine
                let línea = entidad as ReadOnlyLine
                where línea.Closed
                select entidad;
        }
    }
}
