using Domain.Entities.Author;
using Domain.Entities.Book;
using Domain.Entities.Genre;
using Domain.Entities.ManyToMany;
using Infrastructure.Persistence;

namespace Api.Data
{
  public class DbSeed
  {
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
      using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
      {
        var context = serviceScope
          .ServiceProvider
          .GetService<BookMeetsDbContext>();

        context.Database.EnsureCreated();

        if (!context.BookAuthors.Any())
        {
          var authorTimPowers = new Author()
          {
            FullName = "Tim Powers",
            Description = $"Timothy Thomas Powers is an " +
            $"American science fiction and fantasy author." +
            $"Powers has won the World Fantasy Award twice" +
            $" for his critically acclaimed novels Last Call and Declare.",
            ImageUrl = $"https://images.gr-assets.com/authors/1373471978p8/8835.jpg",
            ImagePublicId = String.Empty
          };

          var authorTomVanderbilt = new Author()
          {
            FullName = "Tom Vanderbilt",
            Description = $"Tom Vanderbilt writes on design, technology," +
            $" science, and culture, among other subjects, for many publications," +
            $" including Wired, Outside, The London Review of Books, The Financial Times," +
            $" The Wall Street Journal, The Wilson Quarterly, Artforum, The Wilson Quarterly," +
            $" Travel and Leisure, Rolling Stone, The New York Times Magazine, Cabinet," +
            $" Metropolis, and Popular Science. He is contributing editor to Artforum" +
            $" and the design magazine Print and I.D., contributing writer of the popular" +
            $" blog Design Observer, and columnist for Slate magazine.",
            ImageUrl = $"https://images.gr-assets.com/authors/1392312216p8/326282.jpg",
            ImagePublicId = String.Empty,
          };

          var bookAnubisGates = new Book()
          {
            Title = "The Anubis Gates",
            Description = $"Brendan Doyle, a specialist in the work of the early-nineteenth" +
            $" century poet William Ashbless, reluctantly accepts an invitation from a" +
            $" millionaire to act as a guide to time-travelling tourists. But while" +
            $" attending a lecture given by Samuel Taylor Coleridge in 1810, he becomes" +
            $" marooned in Regency London, where dark and dangerous forces know about the" +
            $" gates in time.\r\n\r\nCaught up in the intrigue between rival bands of beggars," +
            $" pursued by Egyptian sorcerers, and befriended by Coleridge, Doyle somehow" +
            $" survives and learns more about the mysterious Ashbless than he could" +
            $" ever have imagined possible...",
            CoverImageUrl = $"https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1344409006i/142296.jpg",
            CoverImagePublicId = String.Empty,
            CoverType = "Paperback",
            FirstPublished = new DateTime(1983, 12, 1),
            NumberOfPages = 387,

          };

          var bookTraffic = new Book()
          {
            Title = "Traffic: Why We Drive the Way We Do and What It Says About Us",
            Description = $"Would you be surprised that road rage can be" +
            $" good for society? Or that most crashes happen on sunny," +
            $" dry days? That our minds can trick us into thinking the" +
            $" next lane is moving faster? Or that you can gauge a nation" +
            $" s driving behavior by its levels of corruption? These are" +
            $" only a few of the remarkable dynamics that Tom Vanderbilt" +
            $" explores in this fascinating tour through the mysteries of the" +
            $" road.\r\nBased on exhaustive research and interviews with driving" +
            $" experts and traffic officials around the globe, Traffic gets" +
            $" under the hood of the everyday activity of driving to uncover" +
            $" the surprisingly complex web of physical, psychological," +
            $" and technical factors that explain how traffic works, why" +
            $" we drive the way we do, and what our driving says about us." +
            $" Vanderbilt examines the perceptual limits and cognitive" +
            $" underpinnings that make us worse drivers than we think we are." +
            $" He demonstrates why plans to protect pedestrians from cars often" +
            $" lead to more accidents. He shows how roundabouts, which can feel" +
            $" dangerous and chaotic, actually make roads safer and reduce traffic" +
            $" in the bargain. He uncovers who is more likely to honk at whom, and why." +
            $" He explains why traffic jams form, outlines the unintended" +
            $" consequences of our quest for safety, and even identifies the most" +
            $" common mistake drivers make in parking lots.\r\nThe car has long" +
            $" been a central part of American life; whether we see it as a" +
            $" symbol of freedom or a symptom of sprawl, we define ourselves" +
            $" by what and how we drive. As Vanderbilt shows, driving is a" +
            $" provocatively revealing prism for examining how our minds work" +
            $" and the ways in which we interact with one another. Ultimately," +
            $" Traffic is about more than driving: it s about human nature." +
            $" This book will change the way we see ourselves and the world" +
            $" around us. And who knows? It may even make us better drivers.\"",
            CoverImageUrl = $"https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1320428955i/2776527.jpg",
            CoverImagePublicId = String.Empty,
            CoverType = "Hardcover",
            FirstPublished = new DateTime(2008, 07, 29),
            NumberOfPages = 387,
          };

          var genreScience = new Genre()
          {
            Title = "Science",
            Description = $"Science (from the Latin scientia, meaning “knowledge”)" +
            $" is the effort to discover, and increase human understanding of" +
            $" how the physical world works. Through controlled methods," +
            $" science uses observable physical evidence of natural phenomena" +
            $" to collect data, and analyzes this information" +
            $" to explain what and how things work.",
          };
          var genreHistory = new Genre()
          {
            Title = "History",
            Description = $"History (from Greek ἱστορία - historia," +
            $" meaning \"inquiry, knowledge acquired by investigation\")" +
            $" is the discovery, collection, organization, and presentation" +
            $" of information about past events. History can also mean the" +
            $" period of time after writing was invented. Scholars who write" +
            $" about history are called historians. It is a field of research" +
            $" which uses a narrative to examine and analyse the sequence" +
            $" of events, and it sometimes attempts to investigate objectively" +
            $" the patterns of cause and effect that determine events." +
            $" Historians debate the nature of history and its usefulness." +
            $" This includes discussing the study of the discipline as an end " +
            $"in itself and as a way of providing \"perspective\" on the" +
            $" problems of the present. The stories common to a particular" +
            $" culture, but not supported by external sources (such as the" +
            $" legends surrounding King Arthur) are usually classified as" +
            $" cultural heritage rather than the \"disinterested investigation\" needed" +
            $" by the discipline of history. Events of the past prior to written record" +
            $" are considered prehistory.",
          };
          var genreFiction = new Genre()
          {
            Title = "Fiction",
            Description = $"Fiction is the telling" +
            $" of stories which are not real. More" +
            $" specifically, fiction is an imaginative" +
            $" form of narrative, one of the four basic" +
            $" rhetorical modes. Although the word fiction" +
            $" is derived from the Latin fingo, fingere, finxi," +
            $" fictum, \"to form, create\", works of fiction need not" +
            $" be entirely imaginary and may include real people, places," +
            $" and events. Fiction may be either written or oral." +
            $" Although not all fiction is necessarily artistic," +
            $" fiction is largely perceived as a form of art or entertainment." +
            $" The ability to create fiction and other artistic works is" +
            $" considered to be a fundamental aspect of human culture," +
            $" one of the defining characteristics of humanity."
          };
          var genreNonfiction = new Genre()
          {
            Title = "Nonfiction",
            Description = $"Nonfiction is an account or representation" +
            $" of a subject which is presented as fact. This presentation" +
            $" may be accurate or not; that is, it can give either a true" +
            $" or a false account of the subject in question. However, it" +
            $" is generally assumed that the authors of such accounts" +
            $" believe them to be truthful at the time of their composition." +
            $" Note that reporting the beliefs of others in a nonfiction" +
            $" format is not necessarily an endorsement of the ultimate" +
            $" veracity of those beliefs, it is simply saying that it is" +
            $" true that people believe that (for such topics as mythology, religion)." +
            $" Nonfiction can also be written about fiction, giving" +
            $" information about these other works."
          };

          var bookAuthors = new List<BookAuthor>()
          {
            new BookAuthor()
            {
              Book = bookAnubisGates,
              Author = authorTimPowers
            },
            new BookAuthor()
            {
              Book = bookTraffic,
              Author = authorTomVanderbilt
            }
          };

          var bookGenres = new List<BookGenre>()
          {
            new BookGenre()
            {
              Book = bookAnubisGates,
              Genre = genreHistory
            },
            new BookGenre()
            {
              Book = bookAnubisGates,
              Genre = genreFiction
            },
            new BookGenre()
            {
              Book = bookTraffic,
              Genre = genreNonfiction
            },
            new BookGenre()
            {
              Book = bookTraffic,
              Genre = genreHistory
            }
          };

          context.BookAuthors.AddRange(bookAuthors);
          context.BookGenres.AddRange(bookGenres);
          context.SaveChanges();
        }
      }
    }
  }
}
