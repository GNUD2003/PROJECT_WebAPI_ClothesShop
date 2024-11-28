using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project_Data.Migrations
{
    /// <inheritdoc />
    public partial class update_v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "name" },
                values: new object[,]
                {
                    { 1, "Trousers" },
                    { 2, "Shirt" },
                    { 3, "Accessory" },
                    { 4, "Jacket" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cotton" },
                    { 2, "Silk" },
                    { 3, "Leather" },
                    { 4, "Demin" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CateId", "IsActive", "MateId", "countOfProduct", "description", "img_product", "name", "price" },
                values: new object[,]
                {
                    { 1, 2, 1, 1, 0, "OverSize", "https://png.pngtree.com/png-vector/20231011/ourlarge/pngtree-black-t-shirt-mockup-png-image_10216810.png", "Black Shirt", 10f },
                    { 2, 2, 1, 1, 0, "Unisex", "https://product.hstatic.net/1000306633/product/dsc02378_20cb26b74d314381a455691e0f57c305.jpg", "Yellow Shirt", 15f },
                    { 3, 2, 1, 1, 0, "Unisex", "https://bizweb.dktcdn.net/thumb/1024x1024/100/454/935/products/tshirt-all-13-bc6e9eb9-12f1-47c6-a5aa-d57b0b55a970.jpg?v=1682133524350", "Green Shirt", 20f },
                    { 4, 2, 1, 1, 0, "Unisex", "https://png.pngtree.com/png-clipart/20230130/ourlarge/pngtree-realistic-white-t-shirt-vector-for-mockup-png-image_6575804.png", "White Shirt", 20f },
                    { 5, 1, 1, 4, 0, "New Jean", "https://product.hstatic.net/1000306633/product/hades_15sp2861_68d195870f744d1f97b92ece3161fd07.jpg", "SPLINTERED PANTS", 50f },
                    { 6, 1, 1, 4, 0, "Black Jean Collection 2024", "https://product.hstatic.net/1000306633/product/dsc06440_0b8adfc8e5d44cb5b5be6749317ac6fc.jpg", "VINDHEIRM PANTS", 50f },
                    { 7, 1, 1, 4, 0, "Grey Jean New Collection 2024", "https://product.hstatic.net/1000306633/product/group_1_63b8c7543828429d8da58ee55c49ff3b.jpg", "Gray Jean", 50f },
                    { 8, 1, 1, 4, 0, "Wide leg pants, straight form, heel length", "https://product.hstatic.net/1000306633/product/untitled_capture1110_82b081c12676489484ab516558460333.jpg", "Casual Pants", 50f },
                    { 9, 1, 1, 4, 0, "Wash treatment creates a unique effect. Pants are treated with vertical seaming.", "https://product.hstatic.net/1000306633/product/hd_t10.2600_e87fc3429cd54b2589ecc720a60567c9.jpg", "Tectonic Rift Jeans", 50f },
                    { 10, 1, 1, 1, 0, "Baseball cap with typo embroidery on front and left side, soft lining inside. Tear treatment details. Hat has metal button to adjust width at back", "https://product.hstatic.net/1000306633/product/hades5355_f8801511953643219ab90b841c271485.jpg", "PROFILE ELLIPSE CAP", 10f },
                    { 11, 2, 1, 1, 0, "New basic form. Silk screen printing on front and back of shirt", "https://product.hstatic.net/1000306633/product/dsc02378_20cb26b74d314381a455691e0f57c305.jpg", "SLEEPLESS SAIGON TEE", 50f },
                    { 12, 2, 1, 1, 0, "New basic form. Silk screen printing on front and back of shirt", "https://product.hstatic.net/1000306633/product/dsc09856_1d3a8091abae4a6ab6d4e9256df2b4e9.jpg", "CERISE BOW TEE", 50f },
                    { 13, 2, 1, 1, 0, "Tank Top form. Silk screen printing on front and back of shirt", "https://product.hstatic.net/1000306633/product/dsc09825_5bfd1c357e244cb09f9e764802226c89.jpg", "SONOROUS TANK TOP", 50f },
                    { 14, 2, 1, 1, 0, "New basic form. Silk screen printing on front and back of shirt", "https://product.hstatic.net/1000306633/product/truoc_a5458ac1af084d18bcb742c0858a9cec.jpg", "FLEURS RED TEE", 50f },
                    { 15, 2, 1, 1, 0, "New basic form. Silk screen printing on front and back of shirt", "https://product.hstatic.net/1000306633/product/dsc02391_5cd7373e7fee45ec832b2aac535943e2.jpg", "CERISE CRAVAT TEE", 50f },
                    { 16, 2, 1, 1, 0, "Unisex long-sleeved shirt. Stylized H symbol embroidered on front pocket", "https://product.hstatic.net/1000306633/product/hadest62190_1f74f7e3338d464a91a8d6ede97fb24c.jpg", "STRIPED SHIRT 24", 50f },
                    { 17, 2, 1, 1, 0, "2 Bling charms are attached to the front of the shirt", "https://product.hstatic.net/1000306633/product/hades7763_c37388c75a0e4878bfa580e9992199d3.jpg", "WHITE ASTRAL SHIRT", 50f },
                    { 18, 2, 1, 2, 0, "Full body zip. Shirt collar. The shirt body is processed with layering technique on the shirt combined with zip. The lettering on the front of the shirt is silk-screen printed.", "https://product.hstatic.net/1000306633/product/anhtruoc_b151879109654a85ba10e95cf14ac9e5.jpg", "TRACER SLEEVES BOXY SHIRT", 50f },
                    { 19, 4, 1, 3, 0, "Full zip leather jacket. Shirt collar. Front and back details create contrasting color blocks", "https://product.hstatic.net/1000306633/product/dsc04281_970f8f362b644db1827885d9995c8368.jpg", "AQUILINE LEATHER JACKET", 50f },
                    { 20, 4, 1, 3, 0, "Full zip leather jacket. Collar with metal snap button Shop logo", "https://product.hstatic.net/1000306633/product/hades_15sp9026_ec8d570de1384e218bb5295c0f08df67.jpg", "BROWN WAX BIKER JACKET", 50f },
                    { 21, 4, 1, 3, 0, "Full zip leather jacket. Typo graphic on shirt uses a combination of 3 techniques: regular embroidery, embossed embroidery and leather patchwork", "https://product.hstatic.net/1000306633/product/untitled_capture1066_f59c6bb3b46d4b9e899b07424f909096.jpg", "911 LEATHER JACKET", 50f },
                    { 22, 3, 1, 2, 0, "Size: 57 x 57 cm", "https://product.hstatic.net/1000306633/product/khan2_49fd68354ca04168bf8bd280c8ff4b17.jpg", "GOODIES TURBAN", 20f },
                    { 23, 3, 1, 2, 0, "Size: 57 x 57 cm", "https://product.hstatic.net/1000306633/product/khan_1c1016cc7f5c450783adafa38d181647.jpg", "SIGNATURE TURBAN", 20f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
