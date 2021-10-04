using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiHelper
{
    public class DogApiProcessor
    {

        public static async Task<Dictionary<string, List<string>>> LoadBreedList()
        {
            string url = "https://dog.ceo/api/breeds/list/all";
            using (HttpResponseMessage res = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (res.IsSuccessStatusCode)
                {
                    ListBreedModel resultat = await res.Content.ReadAsAsync<ListBreedModel>();
                    return resultat.Breeds;
                }
                else
                {
                    throw new System.Exception(res.ReasonPhrase);
                }
            }
        }

        //public static Task LoadListBreed()
        //{
        //    throw new NotImplementedException();
        //}

        public static async Task<ModelBreed> Load_image(string IMG)
        {
            string url = "https://dog.ceo/api/breed/";
            string random = "/images/random";
            using(HttpResponseMessage res = await ApiHelper.ApiClient.GetAsync(url + IMG + random))
            {
                if(res.IsSuccessStatusCode)
                {
                    ModelBreed b = await res.Content.ReadAsAsync<ModelBreed>();
                    return b;
                }
                else
                {
                    throw new System.Exception(res.ReasonPhrase);
                }
            }
        }
        public static async Task<string> GetImageUrl(string breed)
        {
            /// TODO : GetImageUrl()
            /// TODO : Compléter le modèle manquant
            return string.Empty;
        }
    }
}
