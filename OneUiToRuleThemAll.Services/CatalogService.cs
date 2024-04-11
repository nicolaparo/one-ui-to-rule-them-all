using OneUiToRuleThemAll.Abstractions;
using OneUiToRuleThemAll.Abstractions.Models;

namespace OneUiToRuleThemAll.Services
{
    public class CatalogService : ICatalogService
    {
        private static IEnumerable<ProductData> GetInitialData()
        {
            yield return new ProductData
            {
                Name = "Spade dei Nazgûl",
                Description = "Forgiati con il fuoco dell'Orodruin (Monte Fato), le spade dei Nazgûl sono armi nere e terrificanti, in grado di infliggere ferite spirituali oltre a quelle fisiche.",
                Image = "nazgul-sword",
                Price = 1000
            };
            yield return new ProductData
            {
                Name = "Mazze Chiodate",
                Description = "Grossi bastoni o mazze incisi con punte metalliche, usati per infliggere danni contundenti e terrorizzare i nemici.",
                Image = "spiked-maces",
                Price = 800
            };
            yield return new ProductData
            {
                Name = "Archi Oscuri",
                Description = "Fatti con materiali tenebrosi e magici, gli archi dell'esercito di Sauron possono sparare frecce avvelenate o maledette, causando danni letali e corrompendo le menti dei nemici.",
                Image = "dark-bows",
                Price = 1200
            };
            yield return new ProductData
            {
                Name = "Scudi Incisi",
                Description = "Scudi di ferro o acciaio incisi con rune oscure e simboli maligni, che offrono protezione ai soldati di Sauron e diffondono paura tra i loro avversari.",
                Image = "engraved-shields",
                Price = 1500
            };
            yield return new ProductData
            {
                Name = "Lame Incantate",
                Description = "Spade o coltelli incantati con magia oscura, capaci di infliggere ferite che non guariscono facilmente e corrompere coloro che vengono feriti da esse.",
                Image = "enchanted-blades",
                Price = 1800
            };
            yield return new ProductData
            {
                Name = "Lanciarazzi Orchi",
                Description = "Un'arma primitiva ma efficace, i lanciarazzi orchi sparano proiettili esplosivi o infuocati per seminare distruzione tra le file nemiche.",
                Image = "orc-rocket-launchers",
                Price = 1000
            };
            yield return new ProductData
            {
                Name = "Lanciagrumi Troll",
                Description = "Armi enormi, manovrate dai potenti Troll di Mordor, che lanciano enormi massi o proiettili incendiari contro le fortezze nemiche.",
                Image = "troll-stone-throwers",
                Price = 2000
            };
            yield return new ProductData
            {
                Name = "Armi di Fuoco di Mordor",
                Description = "Sebbene la tecnologia sia limitata nell'universo di Tolkien, potrebbero essere presenti armi primitive simili a cannoni o catapulte che sparano proiettili incendiari o esplosivi.",
                Image = "mordor-firearms",
                Price = 2500
            };
        }
        private readonly List<Product> products = GetInitialData().Select(x => new Product(x) with { Id = Guid.NewGuid() }).ToList();

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            return Task.FromResult<IEnumerable<Product>>(products);
        }
        public Task<Product?> GetProductAsync(Guid id)
        {
            return Task.FromResult(products.FirstOrDefault(p => p.Id == id));
        }
        public Task<Guid> AddProductAsync(ProductData data)
        {
            var product = new Product(data) with { Id = Guid.NewGuid() };
            products.Add(product);
            return Task.FromResult(product.Id);
        }
        public Task<bool> UpdateProductsAsync(Guid productId, ProductData data)
        {
            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product is null)
                return Task.FromResult(false);
            products.Remove(product);
            products.Add(new Product(data) with { Id = productId });
            return Task.FromResult(true);
        }
        public Task<bool> DeleteProductAsync(Guid productId)
        {
            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product is null)
                return Task.FromResult(false);
            products.Remove(product);
            return Task.FromResult(true);
        }

    }

    //public record OrderData
    //{
    //    public string Customer { get; set; }
    //    public List<OrderDetailData> Details { get; set; } = new();
    //}
    //public record OrderDetailData
    //{
    //    public Guid ProductId { get; set; }
    //    public int Quantity { get; set; }
    //}

}
