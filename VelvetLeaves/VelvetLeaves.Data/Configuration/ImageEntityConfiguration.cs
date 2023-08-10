

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public class ImageEntityConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            var imageList = new List<Image>
            {
                //old seed : 
                //new Image {Id = "64be89ae1409e5a61554e6ed", ProductId = 1},
                //new Image {Id = "64be8c68cac3fdf11a06fbbb", ProductId = 1},
                //new Image {Id = "64be8c6df878c3764a814981", ProductId = 1},
                //new Image {Id = "64be8c733df251037e15d70a", ProductId = 2},
                //new Image {Id = "64be8c7a0ef21ca57c247498", ProductId = 2},
                //new Image {Id = "64be8c813d909293463359d6", ProductId = 2},
                //new Image {Id = "64be8c870b7f086367ebb6a5", ProductId = 3},
                //new Image {Id = "64be8c8d7d5c466b820b73af", ProductId = 3},
                //new Image {Id = "64be8c9332b088f8d6063040", ProductId = 4},
                //new Image {Id = "64be8c99f991d074063b5098", ProductId = 4},
                //new Image {Id = "64be8c9f41c19cda7ab19853", ProductId = 5},
                //new Image {Id = "64be8ca5b7f1ea12383c364a", ProductId = 5},
                //new Image {Id = "64be8caa293917f47210277e", ProductId = 6},
                //new Image {Id = "64be8cae1813d7aff61e173b", ProductId = 6},
                //new Image {Id = "64be8cb3b390e17c62039322", ProductId = 7},
                //new Image {Id = "64be8cb81a39dd6ed0351ebb", ProductId = 7}
                //end of old seed: 
                //Текстил
                    //чанти
                        //ленена чанта
                            //слънце
                       
                            new Image {Id = "64d52335b30136c5a68bb051", ProductId = 1},
                            new Image {Id = "64d52338464ff67d85ff46a5", ProductId = 1},
                            new Image {Id = "64d5233c720097ef9dffa9ab", ProductId = 1},
                            new Image {Id = "64d523401c23834259ea6b65", ProductId = 1},
                            new Image {Id = "64d52343c1a58e96abb5c206", ProductId = 1},
                            //синева
                            
                            new Image {Id = "64d5234f5a69fa9f747e5f18", ProductId = 2},
                            new Image {Id = "64d5234ce3785f17243b411c", ProductId = 2},
                            new Image {Id = "64d52349d406df65ce4b4e72", ProductId = 2},
                            new Image {Id = "64d523475af695148db6b205", ProductId = 2},

                    //несесери
                        //ленен несесер
                            //ленен несесер
                            
                            new Image {Id = "64d5235bf6729604d509bc8a", ProductId = 3},
                            new Image {Id = "64d52359322458a957d81660", ProductId = 3},
                            new Image {Id = "64d523565b62f7aaf0663a98", ProductId = 3},
                            new Image {Id = "64d5235287a0f3693212c2a1", ProductId = 3},
                            //ленен несесер
                            
                            new Image {Id = "64d5236abb6d8a6883aea6a5", ProductId = 4},
                            new Image {Id = "64d52366fb8d548ef1e6a1cb", ProductId = 4},
                            new Image {Id = "64d52362ecdfe6871993e1e4", ProductId = 4},
                            new Image {Id = "64d5235f274fb0fcf347d1b3", ProductId = 4},
                    //подвързии
                        //ленена подвързия
                            //ленена подвързия за книга
                            
                            new Image {Id = "64d5237b623df2b2ac3fc610", ProductId = 5},
                            new Image {Id = "64d523760ebe3629aa66effc", ProductId = 5},
                            new Image {Id = "64d52372fe1c9b730442e805", ProductId = 5},
                            new Image {Id = "64d5236e334387ef86d99937", ProductId = 5},
                            //ленена подвързия за Kindle
                            
                            new Image {Id = "64d5237ebfa052d5f7b7e3cb", ProductId = 6},
                            new Image {Id = "64d52385751a53bf32894fb4", ProductId = 6},
                            new Image {Id = "64d52381a7064dcc1dd461d5", ProductId = 6},
                            new Image {Id = "64d5238841449e1eef8fc29a", ProductId = 6},
                //Бижута
                    //обеци
                        //3ка до ухо
                            //червени
                            
                            new Image {Id = "64d5238d2acacb9e2043c933", ProductId = 7},
                            new Image {Id = "64d52392f6a5f8843a780460", ProductId = 7},
                            new Image {Id = "64d523961f6d033d54da856e", ProductId = 7},
                            //жълти
                           
                            new Image {Id = "64d5239a46383aa6559ff15e", ProductId = 8},
                            new Image {Id = "64d5239dfb4154fc78c1b5f2", ProductId = 8},
                            new Image {Id = "64d523a091c723288ab2703f", ProductId = 8},
                        //гроздове
                            //шампанско
                            
                            new Image {Id = "64d523a27541d354f5185ecf", ProductId = 9},
                            new Image {Id = "64d523a54482b6933b4b9641", ProductId = 9},
                            new Image {Id = "64d523a8417674952ae911aa", ProductId = 9},
                            //сини
                          
                            new Image {Id = "64d523ac76b19d54b131024b", ProductId = 10},
                            new Image {Id = "64d523af7736cd67efd18bca", ProductId = 10},
                            new Image {Id = "64d523b1a82f8b465badccfe", ProductId = 10},
                            new Image {Id = "64d523b4aaae78c1fb2e0f19", ProductId = 10},
                            //лилави
                          
                            new Image {Id = "64d523c837c5cbc84815c6b2", ProductId = 11},
                            new Image {Id = "64d523cbc940befd0ef0bbea", ProductId = 11},
                            //жълти
                            
                            new Image {Id = "64d523ceda1ac0b8527ffd26", ProductId = 12},
                            new Image {Id = "64d523d1c01dda3483251e4c", ProductId = 12},
                            //розови
                            
                            new Image {Id = "64d523d49319f1ab11955ee0", ProductId = 13},
                            new Image {Id = "64d523e02eab219eca427579", ProductId = 13},
                            new Image {Id = "64d523e30dd3878eccd3ea1e", ProductId = 13},
                            //жълти
                            
                            new Image {Id = "64d523e7d30950cc175d4ee5", ProductId = 14},
                            new Image {Id = "64d523e985893af2853dbaa4", ProductId = 14},
                            new Image {Id = "64d523ed880a2cfea4e5a29a", ProductId = 14},
                        //дълги
                            //зелено
                          
                            new Image {Id = "64d523f115f347b097321f2a", ProductId = 15},
                            new Image {Id = "64d523f45251d2a11816195f", ProductId = 15},
                            new Image {Id = "64d523f7a6a8571b3eb12359", ProductId = 15},
                            //сакура
                           
                            new Image {Id = "64d523fabe152a47636bae7d", ProductId = 16},
                            new Image {Id = "64d523fdeb4444d63ab86a55", ProductId = 16},
                            new Image {Id = "64d523ff4215c2646cc8163e", ProductId = 16},
                        //на синджир
                            //червени
                           
                            new Image {Id = "64d524022c22a7bf5d6fb592", ProductId = 17},
                            new Image {Id = "64d52405dd648aaccb6de56f", ProductId = 17},
                            new Image {Id = "64d524084074dd02c95d5612", ProductId = 17},
                            //бронз
                            
                            new Image {Id = "64d5240c0d0a9f46840215f4", ProductId = 18},
                            new Image {Id = "64d5240f1f6a4bf88ff5fe28", ProductId = 18},
                            new Image {Id = "64d52413ca2cdb86d5dc5061", ProductId = 18},
                        //тромбон
                            //тромбон
                           
                            new Image {Id = "64d5241605cdc65069fb4e7c", ProductId = 19},
                            new Image {Id = "64d524194292962f1698b35d", ProductId = 19},
                            new Image {Id = "64d5241b4efab879d2b98106", ProductId = 19},
                            new Image {Id = "64d5241ec70acdc88d85b2cf", ProductId = 19},
                    //колиета
                        //гроздове
                            //жълто
                           
                            new Image {Id = "64d52421cfb2a66f5536dbc6", ProductId = 20},
                            new Image {Id = "64d5242462bf6e246eef6de5", ProductId = 20},
                            new Image {Id = "64d5242760c55c37a36657d8", ProductId = 20},
                            //розово
                           
                            new Image {Id = "64d5242b9278a4b37dcc630b", ProductId = 21},
                            new Image {Id = "64d5242e5935e047dede6793", ProductId = 21},
                            new Image {Id = "64d524315e7d9e628e279e40", ProductId = 21},
                        //на обръч
                            //червен
                            
                            new Image {Id = "64d52434e25395fb8679db94", ProductId = 22},
                            new Image {Id = "64d5243d1a39817b5412e11d", ProductId = 22},
                            new Image {Id = "64d524415910ab1c2728156e", ProductId = 22},
                            //зелен
                            
                            new Image {Id = "64d524457ff5157cd75d74b1", ProductId = 23},
                            new Image {Id = "64d52448f4eb7a0a7f25a51a", ProductId = 23},
                            new Image {Id = "64d5244a9e32fb59f283d635", ProductId = 23},
                        //сребро
                            //сребърно колие
                            
                            new Image {Id = "64d52455958cb65afbfd6ae8", ProductId = 24},
                            new Image {Id = "64d5245377429792e179d3bf", ProductId = 24},
                            new Image {Id = "64d524501bda417d5761bfca", ProductId = 24},
                            new Image {Id = "64d5244e355f07301da86f9d", ProductId = 24},
                            //сребърно колие
                           
                            new Image {Id = "64d52464dac819b2d0d9651a", ProductId = 25},
                            new Image {Id = "64d52461873681ea5d64d875", ProductId = 25},
                            new Image {Id = "64d5245e9b617cd236346b63", ProductId = 25},
                            new Image {Id = "64d5245b5f00130edb99f651", ProductId = 25},
                        //кожа
                            //зелено
                            
                            new Image {Id = "64d52468d463b9450c90da10", ProductId = 26},
                            new Image {Id = "64d5246c78ebed5232e6790b", ProductId = 26},
                            //червено
                            
                            new Image {Id = "64d5246f1c85d65d8278ed46", ProductId = 27},
                            new Image {Id = "64d52471ba01308173853a57", ProductId = 27},
                            //колие на кожа с цветя
                           
                            new Image {Id = "64d524758723c98b4517d0e4", ProductId = 28},
                            new Image {Id = "64d52477d20e0caee58a1b13", ProductId = 28},
                        //велур
                            //лилаво
                            
                            new Image {Id = "64d52479338c4bae74412ae2", ProductId = 29},
                            new Image {Id = "64d5247d00dfdad417f95d9a", ProductId = 29},
                            new Image {Id = "64d5247fce219f6b15944ce6", ProductId = 29},
                            //синьо-лилаво
                           
                            new Image {Id = "64d5249591db48402680da4f", ProductId = 30},
                            new Image {Id = "64d524983f05edf1b19fbfcf", ProductId = 30},
                            new Image {Id = "64d5249cf2a4faf6783dcba7", ProductId = 30},
                            //оранжево
                           
                            new Image {Id = "64d5249fbd5f98393548eaf3", ProductId = 31},
                            new Image {Id = "64d524a14f2def8ce5fe2053", ProductId = 31},
                            new Image {Id = "64d524a4d08826759b124b81", ProductId = 31},
                            //тюркоаз
                           
                            new Image {Id = "64d52481af9cd319228bc03e", ProductId = 32},
                            new Image {Id = "64d524848355e8e0ca5c7c64", ProductId = 32},
                            //черно-бяло
                            
                            new Image {Id = "64d52490c7197f5948d686e0", ProductId = 33},
                            new Image {Id = "64d5248ef11f97cf0d936c79", ProductId = 33},
                            new Image {Id = "64d524894f0d449e6e7f0be5", ProductId = 33},
                        //въже
                            //жълто-синьо
                           
                            new Image {Id = "64d524b586fa7d40023defa1", ProductId = 34},
                            new Image {Id = "64d524b05db296b5147b774a", ProductId = 34},
                            new Image {Id = "64d524ace356ce0f5b5e84c6", ProductId = 34},
                            new Image {Id = "64d524a8a106e8030a0f5810", ProductId = 34},
                            //пролет
                            
                            new Image {Id = "64d524b9579b4b54285e15ed", ProductId = 35},
                            new Image {Id = "64d524bc9c0bf598bdbe9551", ProductId = 35},
                            new Image {Id = "64d524bf2b882738a30506c5", ProductId = 35},
                        //стомана
                            //листо
                            
                            new Image {Id = "64d524c23a6c7f3087010b63", ProductId = 36},
                            new Image {Id = "64d524c58d113c6f7108c444", ProductId = 36},
                            new Image {Id = "64d524c8d973ed6ecd116daf", ProductId = 36},
                    //гривни
                        //сребро
                            //розова
                            new Image {Id = "64d524cb8237c4c8cab1c94d", ProductId = 37},
                            //жълта
                            new Image {Id = "64d524ce181e34c33340dd05", ProductId = 38},
                        //кожа
                            //зелена
                           
                            new Image {Id = "64d524d23b4f7df4df352f9f", ProductId = 39},
                            new Image {Id = "64d524d540e46b0cea6cc523", ProductId = 39},
                            new Image {Id = "64d524d99bb7990b020777b9", ProductId = 39},
                            new Image {Id = "64d524db4c9f4a9647db7009", ProductId = 39},
                            //синьо-жълта 
                          
                            new Image {Id = "64d524de44d6b9ac55e41954", ProductId = 40},
                            new Image {Id = "64d524e1def6a193ed8df8f6", ProductId = 40},
                            new Image {Id = "64d524e404b5bd7f13be1c5b", ProductId = 40},
                            new Image {Id = "64d524e80992abcef8352a65", ProductId = 40},
                            new Image {Id = "64d524ebc6f3675710bbd9dd", ProductId = 40},
                    //пръстени
                        //сребро
                            //бял
                           
                            new Image {Id = "64d524fa4584a8013259e40d", ProductId = 41},
                            new Image {Id = "64d52504405b952082fb05d1", ProductId = 41},
                            new Image {Id = "64d52507173da7d7420d2657", ProductId = 41},
                            new Image {Id = "64d5250a13661437bd07c952", ProductId = 41},
                            //син
                           
                            new Image {Id = "64d5250e6b4ba5e401ed0500", ProductId = 42},
                            new Image {Id = "64d52512e2aa2cc2c81f5b6e", ProductId = 42},
                            new Image {Id = "64d52515302802a83f0af2e0", ProductId = 42},
                        //стомана
                            //мак
                           
                            new Image {Id = "64d5251be13c2530fda92d19", ProductId = 43},
                            new Image {Id = "64d5251e9c3ab859c753c597", ProductId = 43},
                            new Image {Id = "64d52521e58195d2403b6e15", ProductId = 43},
                            //жълт
                           
                            new Image {Id = "64d5252751ecfe48e09e1f15", ProductId = 44},
                            new Image {Id = "64d5252abf960bb7827bb75b", ProductId = 44},
                            new Image {Id = "64d5252d8c5ead2168fbd1cb", ProductId = 44},
                            new Image {Id = "64d525319813433aa6afe1ac", ProductId = 44},
            };
        

            builder.HasData(imageList);
        }
    }
}
