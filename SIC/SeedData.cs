using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIC
{
    public static class SeedData
    {
        public static void Init(IServiceProvider serviceProvider)
        {
            using (var context = new SICContext(serviceProvider.GetRequiredService<DbContextOptions<SICContext>>()))
            {
                if (context.Product.Any())
                {
                    return;
                }
                List<Finish> fins = new List<Finish>();
                List<Finish> fins1 = new List<Finish>();
                List<Finish> fins2 = new List<Finish>();
                List<Finish> fins3 = new List<Finish>();
                List<Finish> fins4 = new List<Finish>();

                List<Material> mats = new List<Material>();
                List<Material> mats1 = new List<Material>();
                List<Material> mats2 = new List<Material>();

                List<Dimensions> dims = new List<Dimensions>();
                List<Dimensions> dims1 = new List<Dimensions>();
                List<Dimensions> dims2 = new List<Dimensions>();

                Category father = new Category("Closet");
                Category cat = new Category("Living Room", father);
                Category subcat = new Category("Door knob", cat);

                fins.Add(new Finish("Polished"));

                fins1.Add(new Finish("Polished"));
                fins1.Add(new Finish("Painted"));

                fins2.Add(new Finish("Varnished"));
                fins2.Add(new Finish("Ornamented"));

                fins3.Add(new Finish("Polished"));
                fins3.Add(new Finish("Painted"));

                fins4.Add(new Finish("Polished"));

                dims.Add(new Dimensions(200, 250, 300, null, null, null));
                dims.Add(new Dimensions(300, 300, 300, null, null, null));
                dims.Add(new Dimensions(250, 300, 400, 450, 550, 450));
                dims.Add(new Dimensions(250, 250, 250, 500, 550, 500));

                dims1.Add(new Dimensions(250, 300, 400, null, null, null));//0
                dims1.Add(new Dimensions(650, 650, 650, null, null, null));//3
                dims1.Add(new Dimensions(300, 350, 450, 500, 600, 800));//1
                dims1.Add(new Dimensions(500, 500, 500, 700, 700, 700));//3

                dims2.Add(new Dimensions(250, 300, 450, 500, 600, 700));

                Material mat = new Material("Wood", fins);
                Material mat1 = new Material("Metal", fins1);
                Material mat2 = new Material("Wood", fins2);
                Material mat3 = new Material("Metal", fins3);
                Material mat4 = new Material("Metal", fins4);

                mats.Add(mat);

                mats.Add(mat1);

                mats1.Add(mat2);

                mats1.Add(mat3);

                mats2.Add(mat4);

                Product prod = new Product("prod", dims, mats, cat);

                Product prod1 = new Product("prod1", dims1, mats1, subcat);

                Product prod2 = new Product("LonelyProd", dims2, mats2, father);

                Aggregation aggregation = new Aggregation(prod1, prod);

                RestrictionSizes rest = new RestrictionSizes();
                rest.aggregation = aggregation;
                rest.x = 50.0F;
                rest.y = 50.0F;
                rest.z = 50.0F;

                RestrictionMat rest2 = new RestrictionMat();
                rest2.aggregation = aggregation;
                rest2.containingMaterial = mat3.MaterialId;
                rest2.containedMaterial = mat2.MaterialId;

                context.Product.Add(prod);
                context.Product.Add(prod1);
                context.Product.Add(prod2);

                context.Aggregation.Add(aggregation);

                context.Restriction.Add(rest);
                context.Restriction.Add(rest2);

                context.SaveChanges();
            }
        }
    }
}