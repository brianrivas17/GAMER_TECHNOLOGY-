﻿using GAMER_TECHNOLOGY.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GAMER_TECHNOLOGY.Data.PDF
{
    public interface IFacturaPDF
    {
        FileResult descargarPDF();
        Task GenerarFactura(Pago pago, Checkout checkout, IEnumerable<DetalleFactura> detalle);
    }
}