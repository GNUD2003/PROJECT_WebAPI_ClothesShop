using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project_Data.Migrations
{
    /// <inheritdoc />
    public partial class update_v21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "countOfProduct", "img_product", "name" },
                values: new object[] { 16, "https://product.hstatic.net/1000306633/product/hadesss5271_2b14558975cf4a63ad9846c38d389ae0.jpg", "Pink Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "countOfProduct", "img_product" },
                values: new object[] { 15, "https://product.hstatic.net/1000306633/product/hades_15sp6459_f56b1b52184547be948ca85de8c6945b.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "countOfProduct", "img_product", "name" },
                values: new object[] { 19, "https://product.hstatic.net/1000306633/product/untitled_capture1415_65c895bbd43f4d4592ad13fbdd6c2dec_grande.jpg", "Blue Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "countOfProduct", "img_product" },
                values: new object[] { 14, "https://product.hstatic.net/1000306633/product/untitled_capture0379_382dbd36ba5c47998070f2c5dfdc28d7_grande.jpeg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "countOfProduct",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "countOfProduct",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "countOfProduct",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "countOfProduct",
                value: 70);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CateId", "countOfProduct" },
                values: new object[] { 3, 100 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "countOfProduct",
                value: 70);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "countOfProduct",
                value: 80);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "countOfProduct",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "countOfProduct",
                value: 130);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "countOfProduct",
                value: 140);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "countOfProduct",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "countOfProduct",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "countOfProduct",
                value: 180);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "countOfProduct",
                value: 70);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "countOfProduct",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "countOfProduct",
                value: 140);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "countOfProduct",
                value: 150);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "countOfProduct",
                value: 170);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CateId", "IsActive", "MateId", "countOfProduct", "description", "img_product", "name", "price" },
                values: new object[,]
                {
                    { 24, 1, 1, 4, 210, "Regular fit. Elastic waistband with drawstring. Flared details and vertical slits on front and back of pants. Sshop logo embroidered on front of pants", "https://product.hstatic.net/1000306633/product/hades0097_12db902901f74837a31a277067358285.jpg", "SYMMETRY PANTS", 30f },
                    { 25, 1, 1, 4, 140, "Unisex cropped jeans, knee length, wide leg. Wash treatment creates a unique effect. Stand out with fabric patchwork details and tear treatment on the front. 2 front pockets and 2 back pockets. Lettering embroidered on the back pocket", "https://product.hstatic.net/1000306633/product/hd_t21120_b4ee1be19b714797be823f8d728b4b94.jpg", "WASH JEANS SHORT", 40f },
                    { 26, 1, 1, 4, 10, "Elastic waistband pants with drawstring. Details on pants use silk screen printing technique. Cool fabric, form-fitting", "https://product.hstatic.net/1000306633/product/hd_t21411_5587cc83065e48e0a02206508b25518c.jpg", "SIGNATURE TURBAN", 400f },
                    { 27, 1, 1, 4, 120, "Love Pink", "https://product.hstatic.net/1000306633/product/multi_hong_pant_e33a46466fe64c4982ae4fc543f0b839.jpg", "MULTI TROUSER PANTS", 320f },
                    { 28, 1, 1, 4, 170, "Elastic waistband skirt with drawstring. Using the technique of assembling the front and back of the skirt, 2 front slit pockets and 2 back slit pockets with 2 box pockets. Embroidered lettering. Drawstring at the hem of the skirt for decoration", "https://product.hstatic.net/1000306633/product/z4908503993219_2a3ba233739e6c352441ded60c16ae49_3e0378a895c9427595ff337f4cb745f8.jpg", "NEUTRAL CARGO PARACHUTE SKIRT", 240f },
                    { 29, 1, 1, 4, 110, "Wide leg, low waistband, heel length trousers. Metal Hades logo back button. Sturdy zip pocket details along leg. Decorative belt and metal details", "https://product.hstatic.net/1000306633/product/hd_t21557_90cf650878c64cebad12de2b26654670.jpg", "KNIGHT HUSH PANTS", 210f },
                    { 30, 4, 1, 3, 120, "Full zip jacket. 2 front pockets. Cuffs and body. Front and back details combined with reflective lines create a striking effect. Silk screen printing technique on the front and back of the shirt", "https://product.hstatic.net/1000306633/product/dsc04327_30d4e89a5ca74b098dda2da3532692a3.jpg", "RACER VAIN JACKET", 250f },
                    { 31, 4, 1, 3, 160, "Jacket with zip fastening along the body. Drawstrings on the sleeves and body. Using fabric seaming technique. Lettering details on the front of the shirt are embroidered. There are 2 large front pockets and other metal buttons.", "https://product.hstatic.net/1000306633/product/hades_16.06.23.7405_88fd05cb27fc418783a823b6aea4e26b.jpg", "MAJOR PIECES JACKET", 100f },
                    { 32, 4, 1, 3, 210, "The pocket details are designed to overlap each other. The body and sleeves are trimmed. The lettering details use embossed embroidery techniques. The shirt uses fabric joining techniques. The zipper runs along the body.", "https://product.hstatic.net/1000306633/product/hades_16.06.23.8442_4ce30c9157f7405ba8c92e2defb72917.jpg", "LOOMING ZIP JACKET", 70f },
                    { 33, 4, 1, 3, 110, "Design of 2 large front pockets. Body and sleeve trim. Letters on the shirt use embossed embroidery technique. Stainless steel nameplate attached to the collar. Zipper along the body", "https://product.hstatic.net/1000306633/product/dsc06847_copy_2b565216a330490aa55ac91798b0506d.jpg", "FEEL ALIVE JACKET", 50f },
                    { 34, 4, 1, 3, 310, "Specially embroidered streetwear motifs. Thin lining on the inside. Ribbed collar, cuffs and hem. Snap buttons along the length of the shirt", "https://product.hstatic.net/1000306633/product/2510_1_140d7a21069e4c7a88ddc3f1b04c6a18.jpg", "GLORY ROAD BROWN VARSITY JACKET", 200f },
                    { 35, 3, 1, 3, 20, "Size: large flower 20x20cm, small flower 12x12cm, flower branch 9x3cm, flower leaf 5x2.5cm", "https://product.hstatic.net/1000306633/product/hades_15sp7245_17a8c69e483545de8a53b487873bd8a1.jpg", "BLOOMING CROSS BAG", 220f },
                    { 36, 3, 1, 3, 110, "Sturdy metal zipper2 zipped shoulder straps can be carried in 2 ways. Spacious storage compartment. Decorative rivet details. Waterproof. Dimensions: height 35cm x width 26cm x width 12cm", "https://product.hstatic.net/1000306633/product/hades_15sp9301_0d434600402f4005aa695b095fbf8eb4.jpg", "BACKPACK LEATHER 24", 250f },
                    { 37, 3, 1, 3, 10, "Baseball cap with typo embroidery on front and right side, soft lining inside. Front and back details combined with embossed lines create contrasting color blocks. Hat has metal nameplate to increase or decrease width at the back", "https://product.hstatic.net/1000306633/product/dsc04515_4dab82fb55504989b747f7afbe3dcbf6.jpg", "TAILWIND CAP", 25f },
                    { 38, 3, 1, 3, 60, "Unisex design tote bag. Wolf mascot charm. Shop logo plastic tag. Size: Width 36 x Length 32 (cm)", "https://product.hstatic.net/1000306633/product/hades5649_7424dd8ada6944e2a9f8567dc5f9288c.jpg", "MASCOT BLACK TOTE BAG", 50f },
                    { 39, 3, 1, 3, 50, "Metal Shop Logo. Waterproof. Many spacious storage compartments. Plastic lock details and metal clasps create highlights.", "https://product.hstatic.net/1000306633/product/dsc02422_94b87132902c47f9a362f4c3ce45ad0d.jpg", "NEOPRENE UTILITY BACKPACK", 20f },
                    { 40, 3, 1, 3, 90, "Metal Shop Logo. Sturdy metal zipper and button details. Waterproof. Many compartments and spacious pockets. Dimensions: 42 x 33 x 17cm.", "https://product.hstatic.net/1000306633/product/z5423912627963_73128c420eccecfc5fe2e86113e59334_273e27b606004b19aceba5f77849be77.jpg", "MOTIVATION GRUNGE BACKPACK", 20f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DropColumn(
                name: "status",
                table: "OrderDetails");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "countOfProduct", "img_product", "name" },
                values: new object[] { 50, "https://png.pngtree.com/png-vector/20231011/ourlarge/pngtree-black-t-shirt-mockup-png-image_10216810.png", "Black Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "countOfProduct", "img_product" },
                values: new object[] { 50, "https://product.hstatic.net/1000306633/product/dsc02378_20cb26b74d314381a455691e0f57c305.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "countOfProduct", "img_product", "name" },
                values: new object[] { 50, "https://bizweb.dktcdn.net/thumb/1024x1024/100/454/935/products/tshirt-all-13-bc6e9eb9-12f1-47c6-a5aa-d57b0b55a970.jpg?v=1682133524350", "Green Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "countOfProduct", "img_product" },
                values: new object[] { 50, "https://png.pngtree.com/png-clipart/20230130/ourlarge/pngtree-realistic-white-t-shirt-vector-for-mockup-png-image_6575804.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "countOfProduct",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "countOfProduct",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "countOfProduct",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "countOfProduct",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CateId", "countOfProduct" },
                values: new object[] { 1, 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "countOfProduct",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "countOfProduct",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "countOfProduct",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "countOfProduct",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "countOfProduct",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "countOfProduct",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "countOfProduct",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "countOfProduct",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "countOfProduct",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "countOfProduct",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "countOfProduct",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "countOfProduct",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "countOfProduct",
                value: 50);
        }
    }
}
