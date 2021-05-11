using System;
using System.Drawing;
using System.Linq;

namespace Visual_Crypto
{
    public static class CryptoService
    {
        private static readonly Random random = new Random();

        public static Bitmap MergeImages(Bitmap[] dividedImage)
        {
            var mergedImage = new Bitmap(200, 200);

            for (int x = 0; x < 200; x++)
            {
                for (int y = 0; y < 200; y++)
                {
                    mergedImage.SetPixel(x, y, dividedImage[0].GetPixel(x, y).Name == dividedImage[1].GetPixel(x, y).Name ? Color.White : Color.Black);
                }
            }

            return new Bitmap(mergedImage, 100, 100);
        }

        public static Bitmap[] GenerateDivisions(Bitmap loadedImg)
        {
            Bitmap[] images = Enumerable.Range(0, 2).Select(b => new Bitmap(200, 200)).ToArray();

            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 100; y++)
                {
                    int randomNumber = random.Next(1, 6);

                    if (loadedImg.GetPixel(x, y).Name == "ffffffff")
                    {
                        for (int i = 0; i < images.Length; i++)
                        {
                            switch (randomNumber)
                            {
                                case 1:
                                    images[i].SetPixel(x * 2, y * 2, Color.White);
                                    images[i].SetPixel(x * 2, y * 2 + 1, Color.White);
                                    images[i].SetPixel(x * 2 + 1, y * 2, Color.Black);
                                    images[i].SetPixel(x * 2 + 1, y * 2 + 1, Color.Black);
                                    break;
                                case 2:
                                    images[i].SetPixel(x * 2, y * 2, Color.Black);
                                    images[i].SetPixel(x * 2, y * 2 + 1, Color.Black);
                                    images[i].SetPixel(x * 2 + 1, y * 2, Color.White);
                                    images[i].SetPixel(x * 2 + 1, y * 2 + 1, Color.White);
                                    break;
                                case 3:
                                    images[i].SetPixel(x * 2, y * 2, Color.White);
                                    images[i].SetPixel(x * 2, y * 2 + 1, Color.Black);
                                    images[i].SetPixel(x * 2 + 1, y * 2, Color.White);
                                    images[i].SetPixel(x * 2 + 1, y * 2 + 1, Color.Black);
                                    break;
                                case 4:
                                    images[i].SetPixel(x * 2, y * 2, Color.Black);
                                    images[i].SetPixel(x * 2, y * 2 + 1, Color.White);
                                    images[i].SetPixel(x * 2 + 1, y * 2, Color.Black);
                                    images[i].SetPixel(x * 2 + 1, y * 2 + 1, Color.White);
                                    break;
                                case 5:
                                    images[i].SetPixel(x * 2, y * 2, Color.Black);
                                    images[i].SetPixel(x * 2, y * 2 + 1, Color.White);
                                    images[i].SetPixel(x * 2 + 1, y * 2, Color.White);
                                    images[i].SetPixel(x * 2 + 1, y * 2 + 1, Color.Black);
                                    break;
                                case 6:
                                    images[i].SetPixel(x * 2, y * 2, Color.White);
                                    images[i].SetPixel(x * 2, y * 2 + 1, Color.Black);
                                    images[i].SetPixel(x * 2 + 1, y * 2, Color.Black);
                                    images[i].SetPixel(x * 2 + 1, y * 2 + 1, Color.White);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (randomNumber)
                        {
                            case 1:
                                images[0].SetPixel(x * 2, y * 2, Color.White);
                                images[0].SetPixel(x * 2, y * 2 + 1, Color.White);
                                images[0].SetPixel(x * 2 + 1, y * 2, Color.Black);
                                images[0].SetPixel(x * 2 + 1, y * 2 + 1, Color.Black);

                                images[1].SetPixel(x * 2, y * 2, Color.Black);
                                images[1].SetPixel(x * 2, y * 2 + 1, Color.Black);
                                images[1].SetPixel(x * 2 + 1, y * 2, Color.White);
                                images[1].SetPixel(x * 2 + 1, y * 2 + 1, Color.White);
                                break;
                            case 2:
                                images[0].SetPixel(x * 2, y * 2, Color.Black);
                                images[0].SetPixel(x * 2, y * 2 + 1, Color.Black);
                                images[0].SetPixel(x * 2 + 1, y * 2, Color.White);
                                images[0].SetPixel(x * 2 + 1, y * 2 + 1, Color.White);

                                images[1].SetPixel(x * 2, y * 2, Color.White);
                                images[1].SetPixel(x * 2, y * 2 + 1, Color.White);
                                images[1].SetPixel(x * 2 + 1, y * 2, Color.Black);
                                images[1].SetPixel(x * 2 + 1, y * 2 + 1, Color.Black);
                                break;
                            case 3:
                                images[0].SetPixel(x * 2, y * 2, Color.White);
                                images[0].SetPixel(x * 2, y * 2 + 1, Color.Black);
                                images[0].SetPixel(x * 2 + 1, y * 2, Color.White);
                                images[0].SetPixel(x * 2 + 1, y * 2 + 1, Color.Black);

                                images[1].SetPixel(x * 2, y * 2, Color.Black);
                                images[1].SetPixel(x * 2, y * 2 + 1, Color.White);
                                images[1].SetPixel(x * 2 + 1, y * 2, Color.Black);
                                images[1].SetPixel(x * 2 + 1, y * 2 + 1, Color.White);
                                break;
                            case 4:
                                images[0].SetPixel(x * 2, y * 2, Color.Black);
                                images[0].SetPixel(x * 2, y * 2 + 1, Color.White);
                                images[0].SetPixel(x * 2 + 1, y * 2, Color.Black);
                                images[0].SetPixel(x * 2 + 1, y * 2 + 1, Color.White);

                                images[1].SetPixel(x * 2, y * 2, Color.White);
                                images[1].SetPixel(x * 2, y * 2 + 1, Color.Black);
                                images[1].SetPixel(x * 2 + 1, y * 2, Color.White);
                                images[1].SetPixel(x * 2 + 1, y * 2 + 1, Color.Black);
                                break;
                            case 5:
                                images[0].SetPixel(x * 2, y * 2, Color.Black);
                                images[0].SetPixel(x * 2, y * 2 + 1, Color.White);
                                images[0].SetPixel(x * 2 + 1, y * 2, Color.White);
                                images[0].SetPixel(x * 2 + 1, y * 2 + 1, Color.Black);

                                images[1].SetPixel(x * 2, y * 2, Color.White);
                                images[1].SetPixel(x * 2, y * 2 + 1, Color.Black);
                                images[1].SetPixel(x * 2 + 1, y * 2, Color.Black);
                                images[1].SetPixel(x * 2 + 1, y * 2 + 1, Color.White);
                                break;
                            case 6:
                                images[0].SetPixel(x * 2, y * 2, Color.White);
                                images[0].SetPixel(x * 2, y * 2 + 1, Color.Black);
                                images[0].SetPixel(x * 2 + 1, y * 2, Color.Black);
                                images[0].SetPixel(x * 2 + 1, y * 2 + 1, Color.White);

                                images[1].SetPixel(x * 2, y * 2, Color.Black);
                                images[1].SetPixel(x * 2, y * 2 + 1, Color.White);
                                images[1].SetPixel(x * 2 + 1, y * 2, Color.White);
                                images[1].SetPixel(x * 2 + 1, y * 2 + 1, Color.Black);
                                break;
                        }
                    }
                }
            }
            return images;
        }
    }
}
