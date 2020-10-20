using System;

namespace AJAXItUp.Models
{
    public class Dachi
    {
        public int Fullness { get; set; }
        public int Happiness { get; set; }
        public int Meals { get; set; }
        public int Energy { get; set; }
        public string Message { get; set; }
        public string ImageUrl { get; set; }
        public Dachi()
        {
            Fullness = 20;
            Happiness = 20;
            Meals = 3;
            Energy = 50;
            Message = "Welcome to your Dojodachi! Please don't kill it...";
            ImageUrl = "https://www.clipartkey.com/mpngs/m/35-356826_batman-face-png-batman-cartoon-face-png.png";
        }

        public void Feed()
        {
            if(Meals < 1)
            {
                Message = "You do not have enough meals to feed your little friend.";
                ImageUrl = "https://i.pinimg.com/originals/26/68/64/266864dd749e3c9db461de29954f9e4c.jpg";
                return;
            }

            Random rand = new Random();
            Meals--;
            int fGain = rand.Next(5,11);
            if(rand.Next(1,5) != 1)
            {
                Fullness += fGain;
                Message = $"You fed your buddy and they thought it was delicious! -1 Meal +{fGain} Fullness.";
                ImageUrl = "https://i.ytimg.com/vi/pIGgGV7uwU4/maxresdefault.jpg";
            }
            else
            {
                Message = "Your dojodachi did not like that. -1 Meal";
                ImageUrl = "https://64.media.tumblr.com/367b899c56c85a6f8742945c51098ef7/tumblr_nvbar16Avs1to7enso1_400.jpg";
            }
            return;
        }

        public void Play()
        {
            if(Energy < 5)
            {
                Message = "Your dojodachi does not have enough energy to play.";
                ImageUrl = "https://i.imgur.com/N1Ew8Zf.jpg";
                return;
            }

            Random rand = new Random();
            Energy -= 5;
            int hGain = rand.Next(5,11);

            if(rand.Next(1,5) != 1)
            {
                Happiness += hGain;
                Message = $"You played with your dojodachi, and it had fun! -5 Energy +{hGain} Happiness.";
                ImageUrl = "http://clipart-library.com/image_gallery/n958176.jpg";
            }
            else
            {
                Message = "Your dojodachi did not like that. -5 Energy.";
                ImageUrl = "https://64.media.tumblr.com/367b899c56c85a6f8742945c51098ef7/tumblr_nvbar16Avs1to7enso1_400.jpg";
            }
            return;
        }

        public void Work()
        {
            if(Energy < 5)
            {
                Message = "Your dojodachi does not have enough energy to work.";
                ImageUrl = "https://i.imgur.com/N1Ew8Zf.jpg";
                return;
            }

            Random rand = new Random();
            Energy -= 5;

            int mGain = rand.Next(1,4);
            Meals += mGain;
            Message = $"Your dojodachi worked and earned some food! -5 Energy +{mGain} Meals.";
            ImageUrl = "https://lh3.googleusercontent.com/proxy/8ON8mkKpBUdtN-JeYDft5kLRWp3PiDORvasFl9_31n3qVQsY3SCNmHkYE1DtoWB9GlazmsY-3Io9lW3U3NoOMyBYyTp3SiChWtj15TIoSbyriqnTec4A1qnjueTg";
            return;
        }

        public void Sleep()
        {
            Energy += 15;
            Fullness -= 5;
            Happiness -= 5;

            Message = $"Your dojodachi took a nap. +15 Energy -5 Fullness -5 Happiness.";
            ImageUrl = "https://static0.cbrimages.com/wordpress/wp-content/uploads/2019/10/Batman-Sleeping.jpg?q=50&fit=crop&w=960&h=500";
            return;
        }
    }
}