using CapStoneProofOfConcept.Data;
using CapStoneProofOfConcept.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace CapStoneProofOfConcept.Repositories
{
    public class UserProfileRepository
    {
        private readonly ApplicationDbContext _context;
        private string personalityTypeResult = "";

        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserProfile> GetAll()
        {
            return _context.UserProfile.ToList();
        }

        public UserProfile GetById(int id)
        {
            return _context.UserProfile.FirstOrDefault(uP => uP.Id == id);
        }
        private async Task GetResult(string email)
        {
            var uri = "https://api.talentinsights.com/v1/usage/thisweek?tempaccountcode=X9a9H3tn8uFSH8123447ZvnPAe123447exOfr1AAm3UA123447NCv0Elno%3D&temptoken=aJr1arqYDKsX%2B%2BXCp5b1rQ%3D%3D";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStreamAsync();
                var personalityTypeData = await JsonSerializer.DeserializeAsync<APIResponse>(json);

                foreach (var result in personalityTypeData.Results)
                {
                    if (email == result.Email)
                    {
                        personalityTypeResult = result.Result;
                        break;
                    }
                }
            }
        }


        public async Task Add(UserProfile userPro)
        {
            await GetResult(userPro.Email);
            userPro.PersonalityType = personalityTypeResult;
            _context.Add(userPro);
            _context.SaveChanges();
        }

        public void Update(UserProfile userProfile)
        {
            _context.Entry(userProfile).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var userProfile = GetById(id);
            _context.UserProfile.Remove(userProfile);
            _context.SaveChanges();
        }


    }
}
