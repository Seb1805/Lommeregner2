using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LommeregnerBibliotek
{
    public class Lommeregner
    {
        //Opretter en JSON writer, denne bruges til at skrive i JSON format.
        JsonWriter writer;
        //Constructor der opretter en streawriter
        public Lommeregner()
        {
            //Opretter streamwriteren - File.CreateText laver en ny tekstfil, hvis filen allerede eksiterer åbner den filen
            //og overskriver indholdet
            StreamWriter logFil = File.CreateText("lommeregnerlog.json");
            //????
            logFil.AutoFlush = true;
            writer = new JsonTextWriter(logFil);
            //Aktiverer indent på child objekter
            writer.Formatting = Formatting.Indented;
            //Skriver starten på et JSON object ( { )
            writer.WriteStartObject();
            //Skriver en property med navnet 'Operationer'
            writer.WritePropertyName("Operationer");
            //Skriver begyndelsen på et JSON array ( [ )
            writer.WriteStartArray();

        }

        //Num1 er det første tal, num2 er det andet tal, op er operatoren(+,-,/,*)
        public double LavBeregning(double num1, double num2, string op)
        {
            //Sættes default som Not a Number i tilfælde af brugeren indtaster noget "ulovligt"
            double result = double.NaN;
            //Skriver starten på et JSON objekt ( { )
            writer.WriteStartObject();
            //Skriver en property med navnet operand1
            writer.WritePropertyName("Operand1");
            //Skriver værdien af variablen num1
            writer.WriteValue(num1);
            //Skriver en property med navnet operand2
            writer.WritePropertyName("Operand2");
            //Skriver værdien af variablen num2
            writer.WriteValue(num2);
            //Skriver en property med navnet 'Operator'
            writer.WritePropertyName("Operator");
            switch (op)
            {
                case "p":
                    result = num1 + num2;
                    //Skriver plus som value
                    writer.WriteValue("Plus");
                    break;
                case "m":
                    result = num1 - num2;
                    //Skriver minus som value
                    writer.WriteValue("Minus");
                    break;
                case "g":
                    result = num1 * num2;
                    //Skriver gange som value
                    writer.WriteValue("Gange"); break;
                case "d":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        //Skriver division som value
                        writer.WriteValue("Division");
                    }
                    break;
                default:
                    break;
            }
            //Skriver resultat som property navn
            writer.WritePropertyName("Resultat");
            //Skriver værdien af resultat som value
            writer.WriteValue(result);
            //Lukker JSON objektet ( } )
            writer.WriteEndObject();
            return result;
        }

        //Metode til at skrive slutningen af JSON formattet
        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}
