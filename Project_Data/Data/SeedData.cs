using Microsoft.EntityFrameworkCore;
using Project_Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Data.Data
{
    public class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
            new Role()
            {

                Id = 1,
                RoleCode = "Admin",
                RoleName = "Admin"

            });
            modelBuilder.Entity<Role>().HasData(
            new Role()
            {

                Id = 2,
                RoleCode = "User",
                RoleName = "User"

            });
            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 1,
                name = "Trousers"
            });
            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 2,
                name = "Shirt"
            });
            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 3,
                name = "Accessory"
            });
            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 4,
                name = "Jacket"
            });
            modelBuilder.Entity<Materials>().HasData(new Materials()
            {
                Id = 1,
                Name = "Cotton",

            });
            modelBuilder.Entity<Materials>().HasData(new Materials()
            {
                Id = 2,
                Name = "Silk"
            });
            modelBuilder.Entity<Materials>().HasData(new Materials()
            {
                Id = 3,
                Name = "Leather"
            });
            modelBuilder.Entity<Materials>().HasData(new Materials()
            {
                Id = 4,
                Name = "Demin"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 1,
                name = "Pink Shirt",
                price = 10,
                description = "OverSize",
                CateId = 2,
                countOfProduct = 16,
                MateId = 1,
                img_product = "https://product.hstatic.net/1000306633/product/hadesss5271_2b14558975cf4a63ad9846c38d389ae0.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 2,
                name = "Yellow Shirt",
                price = 15,
                description = "Unisex",
                CateId = 2,
                MateId = 1,
                countOfProduct = 15,
                img_product = "https://product.hstatic.net/1000306633/product/hades_15sp6459_f56b1b52184547be948ca85de8c6945b.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 3,
                name = "Blue Shirt",
                price = 20,
                description = "Unisex",
                CateId = 2,
                countOfProduct = 19,
                MateId = 1,
                img_product = "https://product.hstatic.net/1000306633/product/untitled_capture1415_65c895bbd43f4d4592ad13fbdd6c2dec_grande.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 4,
                name = "White Shirt",
                price = 20,
                description = "Unisex",
                CateId = 2,
                MateId = 1,
                countOfProduct = 14,
                img_product = "https://product.hstatic.net/1000306633/product/untitled_capture0379_382dbd36ba5c47998070f2c5dfdc28d7_grande.jpeg"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 5,
                name = "SPLINTERED PANTS",
                price = 50,
                description = "New Jean",
                CateId = 1,
                MateId = 4,
                countOfProduct = 20,
                img_product = "https://product.hstatic.net/1000306633/product/hades_15sp2861_68d195870f744d1f97b92ece3161fd07.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                price = 50,
                name = "VINDHEIRM PANTS",
                description = "Black Jean Collection 2024",
                CateId = 1,
                MateId = 4,
                countOfProduct = 30,
                img_product = "https://product.hstatic.net/1000306633/product/dsc06440_0b8adfc8e5d44cb5b5be6749317ac6fc.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                price = 50,
                name = "Gray Jean",
                description = "Grey Jean New Collection 2024",
                CateId = 1,
                countOfProduct = 40,
                MateId = 4,
                img_product = "https://product.hstatic.net/1000306633/product/group_1_63b8c7543828429d8da58ee55c49ff3b.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 8,
                name = "Casual Pants",
                price = 50,
                description = "Wide leg pants, straight form, heel length",
                CateId = 1,
                countOfProduct = 50,
                MateId = 4,
                img_product = "https://product.hstatic.net/1000306633/product/untitled_capture1110_82b081c12676489484ab516558460333.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 9,
                name = "Tectonic Rift Jeans",
                price = 50,
                description = "Wash treatment creates a unique effect. Pants are treated with vertical seaming.",
                CateId = 1,
                MateId = 4,
                countOfProduct = 70,
                img_product = "https://product.hstatic.net/1000306633/product/hd_t10.2600_e87fc3429cd54b2589ecc720a60567c9.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 10,
                name = "PROFILE ELLIPSE CAP",
                price = 10,
                description = "Baseball cap with typo embroidery on front and left side, soft lining inside. Tear treatment details. Hat has metal button to adjust width at back",
                CateId = 3,
                MateId = 1,
                countOfProduct = 100,
                img_product = "https://product.hstatic.net/1000306633/product/hades5355_f8801511953643219ab90b841c271485.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 11,
                name = "SLEEPLESS SAIGON TEE",
                price = 50,
                description = "New basic form. Silk screen printing on front and back of shirt",
                CateId = 2,
                MateId = 1,
                countOfProduct = 70,
                img_product = "https://product.hstatic.net/1000306633/product/dsc02378_20cb26b74d314381a455691e0f57c305.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 12,
                name = "CERISE BOW TEE",
                price = 50,
                description = "New basic form. Silk screen printing on front and back of shirt",
                CateId = 2,
                MateId = 1,
                countOfProduct = 80,
                img_product = "https://product.hstatic.net/1000306633/product/dsc09856_1d3a8091abae4a6ab6d4e9256df2b4e9.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 13,
                name = "SONOROUS TANK TOP",
                price = 50,
                description = "Tank Top form. Silk screen printing on front and back of shirt",
                CateId = 2,
                MateId = 1,
                countOfProduct = 120,
                img_product = "https://product.hstatic.net/1000306633/product/dsc09825_5bfd1c357e244cb09f9e764802226c89.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 14,
                name = "FLEURS RED TEE",
                price = 50,
                description = "New basic form. Silk screen printing on front and back of shirt",
                CateId = 2,
                MateId = 1,
                countOfProduct = 130,
                img_product = "https://product.hstatic.net/1000306633/product/truoc_a5458ac1af084d18bcb742c0858a9cec.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 15,
                name = "CERISE CRAVAT TEE",
                price = 50,
                description = "New basic form. Silk screen printing on front and back of shirt",
                CateId = 2,
                countOfProduct = 140,
                MateId = 1,
                img_product = "https://product.hstatic.net/1000306633/product/dsc02391_5cd7373e7fee45ec832b2aac535943e2.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 16,
                name = "STRIPED SHIRT 24",
                price = 50,
                description = "Unisex long-sleeved shirt. Stylized H symbol embroidered on front pocket",
                CateId = 2,
                countOfProduct = 90,
                MateId = 1,
                img_product = "https://product.hstatic.net/1000306633/product/hadest62190_1f74f7e3338d464a91a8d6ede97fb24c.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 17,
                name = "WHITE ASTRAL SHIRT",
                price = 50,
                description = "2 Bling charms are attached to the front of the shirt",
                CateId = 2,
                countOfProduct = 120,
                MateId = 1,
                img_product = "https://product.hstatic.net/1000306633/product/hades7763_c37388c75a0e4878bfa580e9992199d3.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 18,
                name = "TRACER SLEEVES BOXY SHIRT",
                price = 50,
                description = "Full body zip. Shirt collar. The shirt body is processed with layering technique on the shirt combined with zip. The lettering on the front of the shirt is silk-screen printed.",
                CateId = 2,
                countOfProduct = 180,
                MateId = 2,
                img_product = "https://product.hstatic.net/1000306633/product/anhtruoc_b151879109654a85ba10e95cf14ac9e5.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 19,
                name = "AQUILINE LEATHER JACKET",
                price = 50,
                description = "Full zip leather jacket. Shirt collar. Front and back details create contrasting color blocks",
                CateId = 4,
                countOfProduct = 70,
                MateId = 3,
                img_product = "https://product.hstatic.net/1000306633/product/dsc04281_970f8f362b644db1827885d9995c8368.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 20,
                name = "BROWN WAX BIKER JACKET",
                price = 50,
                description = "Full zip leather jacket. Collar with metal snap button Shop logo",
                CateId = 4,
                countOfProduct = 10,
                MateId = 3,
                img_product = "https://product.hstatic.net/1000306633/product/hades_15sp9026_ec8d570de1384e218bb5295c0f08df67.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 21,
                name = "911 LEATHER JACKET",
                price = 50,
                description = "Full zip leather jacket. Typo graphic on shirt uses a combination of 3 techniques: regular embroidery, embossed embroidery and leather patchwork",
                CateId = 4,
                countOfProduct = 140,
                MateId = 3,
                img_product = "https://product.hstatic.net/1000306633/product/untitled_capture1066_f59c6bb3b46d4b9e899b07424f909096.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 22,
                name = "GOODIES TURBAN",
                price = 20,
                description = "Size: 57 x 57 cm",
                CateId = 3,
                countOfProduct = 150,
                MateId = 2,
                img_product = "https://product.hstatic.net/1000306633/product/khan2_49fd68354ca04168bf8bd280c8ff4b17.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 23,
                name = "SIGNATURE TURBAN",
                price = 20,
                description = "Size: 57 x 57 cm",
                CateId = 3,
                countOfProduct = 170,
                MateId = 2,
                img_product = "https://product.hstatic.net/1000306633/product/khan_1c1016cc7f5c450783adafa38d181647.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 24,
                name = "SYMMETRY PANTS",
                price = 30,
                description = "Regular fit. Elastic waistband with drawstring. Flared details and vertical slits on front and back of pants. Sshop logo embroidered on front of pants",
                CateId = 1,
                countOfProduct = 210,
                MateId = 4,
                img_product = "https://product.hstatic.net/1000306633/product/hades0097_12db902901f74837a31a277067358285.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 25,
                name = "WASH JEANS SHORT",
                price = 40,
                description = "Unisex cropped jeans, knee length, wide leg. Wash treatment creates a unique effect. Stand out with fabric patchwork details and tear treatment on the front. 2 front pockets and 2 back pockets. Lettering embroidered on the back pocket",
                CateId = 1,
                countOfProduct = 140,
                MateId = 4,
                img_product = "https://product.hstatic.net/1000306633/product/hd_t21120_b4ee1be19b714797be823f8d728b4b94.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 26,
                name = "SIGNATURE TURBAN",
                price = 400,
                description = "Elastic waistband pants with drawstring. Details on pants use silk screen printing technique. Cool fabric, form-fitting",
                CateId = 1,
                countOfProduct = 10,
                MateId = 4,
                img_product = "https://product.hstatic.net/1000306633/product/hd_t21411_5587cc83065e48e0a02206508b25518c.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 27,
                name = "MULTI TROUSER PANTS",
                price = 320,
                countOfProduct = 120,
                description = "Love Pink",
                CateId = 1,
                MateId = 4,
                img_product = "https://product.hstatic.net/1000306633/product/multi_hong_pant_e33a46466fe64c4982ae4fc543f0b839.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 28,
                name = "NEUTRAL CARGO PARACHUTE SKIRT",
                price = 240,
                description = "Elastic waistband skirt with drawstring. Using the technique of assembling the front and back of the skirt, 2 front slit pockets and 2 back slit pockets with 2 box pockets. Embroidered lettering. Drawstring at the hem of the skirt for decoration",
                CateId = 1,
                countOfProduct = 170,
                MateId = 4,
                img_product = "https://product.hstatic.net/1000306633/product/z4908503993219_2a3ba233739e6c352441ded60c16ae49_3e0378a895c9427595ff337f4cb745f8.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 29,
                name = "KNIGHT HUSH PANTS",
                price = 210,
                description = "Wide leg, low waistband, heel length trousers. Metal Hades logo back button. Sturdy zip pocket details along leg. Decorative belt and metal details",
                CateId = 1,
                countOfProduct = 110,
                MateId = 4,
                img_product = "https://product.hstatic.net/1000306633/product/hd_t21557_90cf650878c64cebad12de2b26654670.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 30,
                name = "RACER VAIN JACKET",
                price = 250,
                description = "Full zip jacket. 2 front pockets. Cuffs and body. Front and back details combined with reflective lines create a striking effect. Silk screen printing technique on the front and back of the shirt",
                CateId = 4,
                countOfProduct = 120,
                MateId = 3,
                img_product = "https://product.hstatic.net/1000306633/product/dsc04327_30d4e89a5ca74b098dda2da3532692a3.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 31,
                name = "MAJOR PIECES JACKET",
                price = 100,
                description = "Jacket with zip fastening along the body. Drawstrings on the sleeves and body. Using fabric seaming technique. Lettering details on the front of the shirt are embroidered. There are 2 large front pockets and other metal buttons.",
                CateId = 4,
                countOfProduct = 160,
                MateId = 3,
                img_product = "https://product.hstatic.net/1000306633/product/hades_16.06.23.7405_88fd05cb27fc418783a823b6aea4e26b.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 32,
                name = "LOOMING ZIP JACKET",
                price = 70,
                description = "The pocket details are designed to overlap each other. The body and sleeves are trimmed. The lettering details use embossed embroidery techniques. The shirt uses fabric joining techniques. The zipper runs along the body.",
                CateId = 4,
                countOfProduct = 210,
                MateId = 3,
                img_product = "https://product.hstatic.net/1000306633/product/hades_16.06.23.8442_4ce30c9157f7405ba8c92e2defb72917.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 33,
                name = "FEEL ALIVE JACKET",
                price = 50,
                description = "Design of 2 large front pockets. Body and sleeve trim. Letters on the shirt use embossed embroidery technique. Stainless steel nameplate attached to the collar. Zipper along the body",
                CateId = 4,
                countOfProduct = 110,
                MateId = 3,
                img_product = "https://product.hstatic.net/1000306633/product/dsc06847_copy_2b565216a330490aa55ac91798b0506d.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 34,
                name = "GLORY ROAD BROWN VARSITY JACKET",
                price = 200,
                description = "Specially embroidered streetwear motifs. Thin lining on the inside. Ribbed collar, cuffs and hem. Snap buttons along the length of the shirt",
                CateId = 4,
                countOfProduct = 310,
                MateId = 3,
                img_product = "https://product.hstatic.net/1000306633/product/2510_1_140d7a21069e4c7a88ddc3f1b04c6a18.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 35,
                name = "BLOOMING CROSS BAG",
                price = 220,
                description = "Size: large flower 20x20cm, small flower 12x12cm, flower branch 9x3cm, flower leaf 5x2.5cm",
                CateId = 3,
                countOfProduct = 20,
                MateId = 3,
                img_product = "https://product.hstatic.net/1000306633/product/hades_15sp7245_17a8c69e483545de8a53b487873bd8a1.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 36,
                name = "BACKPACK LEATHER 24",
                price = 250,
                countOfProduct = 110,
                description = "Sturdy metal zipper2 zipped shoulder straps can be carried in 2 ways. Spacious storage compartment. Decorative rivet details. Waterproof. Dimensions: height 35cm x width 26cm x width 12cm",
                CateId = 3,
                MateId = 3,
                img_product = "https://product.hstatic.net/1000306633/product/hades_15sp9301_0d434600402f4005aa695b095fbf8eb4.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 37,
                name = "TAILWIND CAP",
                price = 25,
                description = "Baseball cap with typo embroidery on front and right side, soft lining inside. Front and back details combined with embossed lines create contrasting color blocks. Hat has metal nameplate to increase or decrease width at the back",
                CateId = 3,
                countOfProduct = 10,
                MateId = 3,
                img_product = "https://product.hstatic.net/1000306633/product/dsc04515_4dab82fb55504989b747f7afbe3dcbf6.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 38,
                name = "MASCOT BLACK TOTE BAG",
                price = 50,
                description = "Unisex design tote bag. Wolf mascot charm. Shop logo plastic tag. Size: Width 36 x Length 32 (cm)",
                CateId = 3,
                countOfProduct = 60,
                MateId = 3,
                img_product = "https://product.hstatic.net/1000306633/product/hades5649_7424dd8ada6944e2a9f8567dc5f9288c.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 39,
                name = "NEOPRENE UTILITY BACKPACK",
                price = 20,
                description = "Metal Shop Logo. Waterproof. Many spacious storage compartments. Plastic lock details and metal clasps create highlights.",
                CateId = 3,

                MateId = 3,
                img_product = "https://product.hstatic.net/1000306633/product/dsc02422_94b87132902c47f9a362f4c3ce45ad0d.jpg",
                countOfProduct = 50
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 40,
                name = "MOTIVATION GRUNGE BACKPACK",
                price = 20,
                description = "Metal Shop Logo. Sturdy metal zipper and button details. Waterproof. Many compartments and spacious pockets. Dimensions: 42 x 33 x 17cm.",
                CateId = 3,
                MateId = 3,
                countOfProduct = 90,
                img_product = "https://product.hstatic.net/1000306633/product/z5423912627963_73128c420eccecfc5fe2e86113e59334_273e27b606004b19aceba5f77849be77.jpg"
            });
        }
    }
}

/* modelBuilder.Entity<Product>().HasData(new Product()
 {
     Id = 1,
     name = "Black Shirt",
     price = 10,
     description = "OverSize",
     CateId = 2,
     MateId = 1,
     img_product = "https://png.pngtree.com/png-vector/20231011/ourlarge/pngtree-black-t-shirt-mockup-png-image_10216810.png",
     countOfProduct = 50

 });
 modelBuilder.Entity<Product>().HasData(new Product()
 {
     Id = 2,
     name = "Yellow Shirt",
     price = 15,
     description = "Unisex",
     CateId = 2,
     MateId = 1,
     img_product = "https://product.hstatic.net/1000306633/product/dsc02378_20cb26b74d314381a455691e0f57c305.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product()
 {
     Id = 3,
     name = "Green Shirt",
     price = 20,
     description = "Unisex",
     CateId = 2,
     MateId = 1,
     img_product = "https://bizweb.dktcdn.net/thumb/1024x1024/100/454/935/products/tshirt-all-13-bc6e9eb9-12f1-47c6-a5aa-d57b0b55a970.jpg?v=1682133524350",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product()
 {
     Id = 4,
     name = "White Shirt",
     price = 20,
     description = "Unisex",
     CateId = 2,
     MateId = 1,
     img_product = "https://png.pngtree.com/png-clipart/20230130/ourlarge/pngtree-realistic-white-t-shirt-vector-for-mockup-png-image_6575804.png",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product()
 {
     Id = 5,
     name = "SPLINTERED PANTS",
     price = 50,
     description = "New Jean",
     CateId = 1,
     MateId = 4,
     img_product = "https://product.hstatic.net/1000306633/product/hades_15sp2861_68d195870f744d1f97b92ece3161fd07.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 6,
     price = 50,
     name = "VINDHEIRM PANTS",
     description = "Black Jean Collection 2024",
     CateId = 1,
     MateId = 4,
     img_product = "https://product.hstatic.net/1000306633/product/dsc06440_0b8adfc8e5d44cb5b5be6749317ac6fc.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 7,
     price = 50,
     name = "Gray Jean",
     description = "Grey Jean New Collection 2024",
     CateId = 1,
     MateId = 4,
     img_product = "https://product.hstatic.net/1000306633/product/group_1_63b8c7543828429d8da58ee55c49ff3b.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 8,
     name = "Casual Pants",
     price = 50,
     description = "Wide leg pants, straight form, heel length",
     CateId = 1,
     MateId = 4,
     img_product = "https://product.hstatic.net/1000306633/product/untitled_capture1110_82b081c12676489484ab516558460333.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 9,
     name = "Tectonic Rift Jeans",
     price = 50,
     description = "Wash treatment creates a unique effect. Pants are treated with vertical seaming.",
     CateId = 1,
     MateId = 4,
     img_product = "https://product.hstatic.net/1000306633/product/hd_t10.2600_e87fc3429cd54b2589ecc720a60567c9.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 10,
     name = "PROFILE ELLIPSE CAP",
     price = 10,
     description = "Baseball cap with typo embroidery on front and left side, soft lining inside. Tear treatment details. Hat has metal button to adjust width at back",
     CateId = 1,
     MateId = 1,
     img_product = "https://product.hstatic.net/1000306633/product/hades5355_f8801511953643219ab90b841c271485.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 11,
     name = "SLEEPLESS SAIGON TEE",
     price = 50,
     description = "New basic form. Silk screen printing on front and back of shirt",
     CateId = 2,
     MateId = 1,
     img_product = "https://product.hstatic.net/1000306633/product/dsc02378_20cb26b74d314381a455691e0f57c305.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 12,
     name = "CERISE BOW TEE",
     price = 50,
     description = "New basic form. Silk screen printing on front and back of shirt",
     CateId = 2,
     MateId = 1,
     img_product = "https://product.hstatic.net/1000306633/product/dsc09856_1d3a8091abae4a6ab6d4e9256df2b4e9.jpg",
     countOfProduct = 50

 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 13,
     name = "SONOROUS TANK TOP",
     price = 50,
     description = "Tank Top form. Silk screen printing on front and back of shirt",
     CateId = 2,
     MateId = 1,
     img_product = "https://product.hstatic.net/1000306633/product/dsc09825_5bfd1c357e244cb09f9e764802226c89.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 14,
     name = "FLEURS RED TEE",
     price = 50,
     description = "New basic form. Silk screen printing on front and back of shirt",
     CateId = 2,
     MateId = 1,
     img_product = "https://product.hstatic.net/1000306633/product/truoc_a5458ac1af084d18bcb742c0858a9cec.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 15,
     name = "CERISE CRAVAT TEE",
     price = 50,
     description = "New basic form. Silk screen printing on front and back of shirt",
     CateId = 2,
     MateId = 1,
     img_product = "https://product.hstatic.net/1000306633/product/dsc02391_5cd7373e7fee45ec832b2aac535943e2.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 16,
     name = "STRIPED SHIRT 24",
     price = 50,
     description = "Unisex long-sleeved shirt. Stylized H symbol embroidered on front pocket",
     CateId = 2,
     MateId = 1,
     img_product = "https://product.hstatic.net/1000306633/product/hadest62190_1f74f7e3338d464a91a8d6ede97fb24c.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 17,
     name = "WHITE ASTRAL SHIRT",
     price = 50,
     description = "2 Bling charms are attached to the front of the shirt",
     CateId = 2,
     MateId = 1,
     img_product = "https://product.hstatic.net/1000306633/product/hades7763_c37388c75a0e4878bfa580e9992199d3.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 18,
     name = "TRACER SLEEVES BOXY SHIRT",
     price = 50,
     description = "Full body zip. Shirt collar. The shirt body is processed with layering technique on the shirt combined with zip. The lettering on the front of the shirt is silk-screen printed.",
     CateId = 2,
     MateId = 2,
     img_product = "https://product.hstatic.net/1000306633/product/anhtruoc_b151879109654a85ba10e95cf14ac9e5.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 19,
     name = "AQUILINE LEATHER JACKET",
     price = 50,
     description = "Full zip leather jacket. Shirt collar. Front and back details create contrasting color blocks",
     CateId = 4,
     MateId = 3,
     img_product = "https://product.hstatic.net/1000306633/product/dsc04281_970f8f362b644db1827885d9995c8368.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 20,
     name = "BROWN WAX BIKER JACKET",
     price = 50,
     description = "Full zip leather jacket. Collar with metal snap button Shop logo",
     CateId = 4,
     MateId = 3,
     img_product = "https://product.hstatic.net/1000306633/product/hades_15sp9026_ec8d570de1384e218bb5295c0f08df67.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 21,
     name = "911 LEATHER JACKET",
     price = 50,
     description = "Full zip leather jacket. Typo graphic on shirt uses a combination of 3 techniques: regular embroidery, embossed embroidery and leather patchwork",
     CateId = 4,
     MateId = 3,
     img_product = "https://product.hstatic.net/1000306633/product/untitled_capture1066_f59c6bb3b46d4b9e899b07424f909096.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 22,
     name = "GOODIES TURBAN",
     price = 20,
     description = "Size: 57 x 57 cm",
     CateId = 3,
     MateId = 2,
     img_product = "https://product.hstatic.net/1000306633/product/khan2_49fd68354ca04168bf8bd280c8ff4b17.jpg",
     countOfProduct = 50
 });
 modelBuilder.Entity<Product>().HasData(new Product
 {
     Id = 23,
     name = "SIGNATURE TURBAN",
     price = 20,
     description = "Size: 57 x 57 cm",
     CateId = 3,
     MateId = 2,
     img_product = "https://product.hstatic.net/1000306633/product/khan_1c1016cc7f5c450783adafa38d181647.jpg",
     countOfProduct = 50
 });
}
}
}*/
