using KeysShop.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysShop.Repository
{
    public class KeysRepository
    {
        private readonly KeysShopContext _ctx;

        public KeysRepository(KeysShopContext _ctx)
        {
            this._ctx = _ctx;
        }

        public async Task AddKeyAsync(Key key)
        {
            _ctx.Keys.Add(key);
            await _ctx.SaveChangesAsync();
        }

        public Key GetKey(int id)
        {
            return _ctx.Keys.Include(x=>x.Brand).Include(x=>x.feedbacks).FirstOrDefault(x => x.Id == id);

        }

        public List<Key> GetKeys()
        {
            var keyList = _ctx.Keys.ToList();
            return keyList;
        }

        public async Task DeleteKeyAsync(int id)
        {
            _ctx.Remove(GetKey(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateKeyAsync(Key updatedKey)
        {
            var key = _ctx.Keys.FirstOrDefault(x => x.Id == updatedKey.Id);
            key.Name = updatedKey.Name;
            key.Description = updatedKey.Description;
            key.Price = updatedKey.Price;
            key.Sale = updatedKey.Sale;
            key.Frequency = updatedKey.Frequency;
            key.Count = updatedKey.Count;
            key.ImgPath = updatedKey.ImgPath;
            key.IsOriginal = updatedKey.IsOriginal;
            key.IsKeyless = updatedKey.IsKeyless;
            key.Brand = updatedKey.Brand;
            key.feedbacks = updatedKey.feedbacks;
            await _ctx.SaveChangesAsync();
        }
    }
}
