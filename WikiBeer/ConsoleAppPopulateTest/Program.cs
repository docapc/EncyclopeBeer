﻿/*
  Test de peuplement de la base de donnée.
    Sur les problème de sérialisation/désérialisation : NewTon Soft est une solution mais aps très sécure!
    La manière propre de faire seriat de passer par System.Net.Http.Json qui utilise System.Net.Http.Json.
    Il faut ensuite passer à JsonSerializerOptions un JsonConverter<T> qu'il faut implémenter soit même!
https://stackoverflow.com/questions/58074304/is-polymorphic-deserialization-possible-in-system-text-json
https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-converters-how-to?pivots=dotnet-6-0#support-polymorphic-deserialization
https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-polymorphism.
    On peut également resté sur NewtonSoft et gérer ensuite la tranformation coté angular via 
https://github.com/typestack/class-transformer
    Voir également
https://github.com/manuc66/JsonSubTypes
 */
using AutoFixture;
using AutoFixture.Kernel;
using AutoMapper;
using Ipme.WikiBeer.ApiDatas;
using Ipme.WikiBeer.ApiDatas.MapperProfiles;
using Ipme.WikiBeer.Models;
using Ipme.WikiBeer.Models.Ingredients;

// Config Automappeur 
var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(DtoModelProfile)));
var mapper = new Mapper(configuration);

// Config Autofixture
var fixture = new Fixture();
fixture.Customizations.Add(new TypeRelay(typeof(IngredientModel), typeof(HopModel)));

// Configuration BeerManager
var url = "https://localhost:7160";
var client = new HttpClient();
var beerManager = new BeerDataManager(client, mapper, url);

#region Création d'une bière
// Pays
var belgique = new CountryModel(name: "Belgique");
var france = new CountryModel(name: "France");
var ecosse = new CountryModel(name: "Ecosse");

// Brasseries
var brewdog = new BreweryModel(name: "Brewdog", description: "Des chiens qui brassent", country: ecosse);
var linderman = new BreweryModel(name: "Brasserie Lindemans", description: "...", country: belgique);
var ninkasi = new BreweryModel(name: "Ninkasi", description: "...", country: france);

// Couleurs
var blonde = new BeerColorModel(name: "Blonde");
var brune = new BeerColorModel(name: "Brune");
var blanche = new BeerColorModel(name: "Blanche");

// Styles
var ipa = new BeerStyleModel(name: "IPA", description: "");
var lambic = new BeerStyleModel(name: "Lambic", description: "");
var speciale = new BeerStyleModel(name: "Spéciale", description: "");
var apa = new BeerStyleModel(name: "American pale ale", description: "");
var smok = new BeerStyleModel(name: "Smoked Beer", description: "");
var ale = new BeerStyleModel(name: "Blonde Ale", description: "");

// Ingredients
var hop = new HopModel(name: "Houblon", description: "desc", alphaAcid: 4);
var malt = new CerealModel(name: "Malt d'orge", description: "desc", ebc: 4);
var water = new AdditiveModel(name: "Eau", description: "de source", use: "pour rendre la bière liquide mon pote !");
IEnumerable<IngredientModel> ingredients = new List<IngredientModel> { hop, malt, water };

// Bières en elle même
var pony = new BeerModel("DEAD PONY CLUB", 8, 4, apa, blonde, brewdog, ingredients);
//var peche = new BeerModel("La Pêcheresse", 10, 4, lambic, blonde, linderman, ingredients);

#endregion

// Test ajout beer avec ingredient (et Color) déjà en base
//await beerManager.Add(pony);
var beers = await beerManager.GetAll();
var new_pony = await beerManager.GetById(beers.ToList()[0].Id);
var peche = new BeerModel("La Pêcheresse", 10, 4, lambic, new_pony.Color, linderman, new_pony.Ingredients);
await beerManager.Add(peche);

// Création liste de bières 
//var beers = new List<BeerModel> { pony, peche };

// Injection bière dans la database. Attention en faisant comme sa on duplique plusieurs objets en bdd
// Pour éviter sa il faudrait injecter une bière, récupérer les Guid des objets communs à tt (ingrédient, couleur), 
// les donner aux modèles, puis faire un add de la beer en question (serait un bon test pour voir si la base est bien branlé!)
//foreach (var beer in beers)
//{
//    await beerManager.Add(beer);
//}


Console.WriteLine("Execution terminée");
Console.ReadLine();

//
//var punk = new BeerModel();
//punk.Name = "Punk IPA";
//punk.Brewery = brewdog;
//punk.Ibu = 10;
//punk.Degree = 5;
//punk.Color = blonde;
//punk.Style = ipa;
//punk.Ingredients = ingredient;

//await beerManager.Add(punk);

//var tokyo = new BeerModel();
//tokyo.Name = "Tokyo";
//tokyo.Brewery = brewdog;
//tokyo.Ibu = 5;
//tokyo.Degree = 6;
//tokyo.Color = brune;
//tokyo.Style = speciale;

//await beerManager.Add(tokyo);

//var pony = new BeerModel();
//pony.Name = "DEAD PONY CLUB";
//pony.Brewery = brewdog;
//pony.Ibu = 8;
//pony.Degree = 4;
//pony.Color = blonde;
//pony.Style = apa;

//var kriek = new BeerModel();
//kriek.Name = "Lindemans Kriek";
//kriek.Brewery = linderman;
//kriek.Ibu = 8;
//kriek.Degree = 4;
//kriek.Color = blonde;
//kriek.Style = lambic;

//await beerManager.Add(kriek);

//var smoky = new BeerModel();
//smoky.Name = "Smoky Oak Ale";
//smoky.Brewery = ninkasi;
//smoky.Ibu = 8;
//smoky.Degree = 4;
//smoky.Color = brune;
//smoky.Style = smok;

//await beerManager.Add(smoky);

//var mango = new BeerModel();
//mango.Name = "Mango No°5";
//mango.Brewery = ninkasi;
//mango.Ibu = 8;
//mango.Degree = 4;
//mango.Color = blonde;
//mango.Style = ale;

//await beerManager.Add(mango);
