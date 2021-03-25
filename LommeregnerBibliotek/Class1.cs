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
            //Opretter streamwriteren
            StreamWriter logFil = File.CreateText("lommeregnerlog.json");
            logFil.AutoFlush = true;
            writer = new JsonTextWriter(logFil);
            writer.Formatting = Formatting.Indented;
            //Skriver starten på et JSON object
            writer.WriteStartObject();
            //Skriver property navnet
            writer.WritePropertyName("Operationer");
            //Skriver begyndelsen på et JSON array
            writer.WriteStartArray();

        }

        //Num1 er det første tal, num2 er det andet tal, op er operatoren(+,-,/,*)
        public double LavBeregning(double num1, double num2, string op)
        {
            //Sættes default som Not a Number i tilfælde af brugeren indtaster noget "ulovligt"
            double result = double.NaN;
            //Skriver starten på et JSON objekt
            writer.WriteStartObject();
            //Skriver operand1
            writer.WritePropertyName("Operand1");
            //Skriver tal 1
            writer.WriteValue(num1);
            //Skriver operand2
            writer.WritePropertyName("Operand2");
            //Skriver tal 2
            writer.WriteValue(num2);
            //Skriver operator
            writer.WritePropertyName("Operator");
            switch (op)
            {
                case "p":
                    result = num1 + num2;
                    //Skriver plus
                    writer.WriteValue("Plus");
                    break;
                case "m":
                    result = num1 - num2;
                    //Skriver minus
                    writer.WriteValue("Minus");
                    break;
                case "g":
                    result = num1 * num2;
                    //Skriver gange
                    writer.WriteValue("Gange"); break;
                case "d":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        //Skriver division
                        writer.WriteValue("Division");
                    }
                    break;
                default:
                    break;
            }
            //Skriver resultat
            writer.WritePropertyName("Resultat");
            //Skriver værdien af resultat
            writer.WriteValue(result);
            //Lukker JSON objektet
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
