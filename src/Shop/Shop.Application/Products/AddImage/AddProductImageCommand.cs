﻿using Common.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Products.AddImage
{
    public class AddProductImageCommand:IBaseCommand
    {
        public AddProductImageCommand(IFormFile imageFile, Guid productId, int sequence)
        {
            ImageFile = imageFile;
            ProductId = productId;
            Sequence = sequence;
        }

        public IFormFile ImageFile { get; private set; }
        public Guid ProductId { get; private set; }
        public int Sequence { get; private set; }
    }
}

