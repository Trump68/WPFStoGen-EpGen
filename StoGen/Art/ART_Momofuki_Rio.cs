using StoGen.Classes.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Art
{
    public class ART_Momofuki_Rio : Person
    {

        public ART_Momofuki_Rio() : base()
        {
            ImagePath = @"e:\!STOGENDB\READY\ART\Momofuki_Rio\";
            Name = "ART of Momofuki Rio";
            Type = "ART";
        }


        public static ART_Momofuki_Rio Load()
        {
            ART_Momofuki_Rio art = new ART_Momofuki_Rio();
           
            for (int ii = 1; ii <= 83; ii++)
            {
                art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{ii}", $@"{art.ImagePath}{ii.ToString("D3")}.jpg", "Обложка", "Цвет", art.Name)); 
            }

            int i = 84;
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1000}", $@"{art.ImagePath}002a.jpg", "", "",art.Name));i++;
            art.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Feature.MouthNormal}{1000}", $@"{art.ImagePath}002-mouth01.png", "", "", art.Name)); i++;
            art.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.NipplesGeneric},{Feature.FeatureNipples}{1000}", $@"{art.ImagePath}002-nipples01.png", "", "", art.Name)); i++;
            art.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.BlushGeneric},{Feature.FeatureBlush}{1000}", $@"{art.ImagePath}002-blush01.png", "", "", art.Name)); i++;

            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1001}", $@"{art.ImagePath}003a.jpg", "", "", art.Name)); i++;
            art.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Feature.MouthNormal}{1001}", $@"{art.ImagePath}003-mouth01.png", "", "", art.Name)); i++;

            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1002}", $@"{art.ImagePath}002b.jpg", "", "", art.Name)); i++;
            art.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Feature.MouthNormal}{1002}", $@"{art.ImagePath}002-mouth02.png", "", "", art.Name)); i++;

            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1003}", $@"{art.ImagePath}004a.jpg", "", "", art.Name)); i++;
            art.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Feature.MouthNormal}{1003}", $@"{art.ImagePath}004-mouth01.png", "", "", art.Name)); i++;

            return art;
        }

    }
}
