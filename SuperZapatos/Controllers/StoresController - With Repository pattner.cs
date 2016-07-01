using SuperZapatos.Models;
using SuperZapatos.RepositoryPattern.Concrete;
using SuperZapatos.RepositoryPattern.Contracts;
using SuperZapatos.RepositoryPattern.Repositories;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace SuperZapatos.Controllers
{
    //public class StoresController : ApiController
    //{
    //    #region Fields

    //    private StoreRepository repository = null;

    //    private IUnitOfWork myUOW = null;

    //    #endregion

    //    #region Properties

    //    public IUnitOfWork UOW
    //    {
    //        get
    //        {
    //            if (this.myUOW == null)
    //            {
    //                this.myUOW = new UnitOfWork();
    //            }

    //            return this.myUOW;
    //        }
    //    }

    //    #endregion

    //    #region Constructors

    //    public StoresController()
    //    {
    //        this.repository = new StoreRepository(this.UOW);
    //    }

    //    #endregion

    //    #region Methods

    //    // GET: api/Stores
    //    public IQueryable<Store> GetStores()
    //    {
    //        return this.repository.GetAll().AsQueryable();
    //    }

    //    // GET: api/Stores/5
    //    [ResponseType(typeof(Store))]
    //    public async Task<IHttpActionResult> GetStore(int id)
    //    {
    //        Store store = this.repository.Single(id);
    //        if (store == null)
    //        {
    //            return NotFound();
    //        }

    //        return Ok(store);
    //    }

    //    // PUT: api/Stores/5
    //    [ResponseType(typeof(void))]
    //    public async Task<IHttpActionResult> PutStore(int id, Store store)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        if (id != store.id)
    //        {
    //            return BadRequest();
    //        }

    //        try
    //        {
    //            this.repository.Update(store);
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!StoreExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return StatusCode(HttpStatusCode.NoContent);
    //    }

    //    // POST: api/Stores
    //    [ResponseType(typeof(Store))]
    //    public async Task<IHttpActionResult> PostStore(Store store)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        store.id = this.repository.Insert(store);

    //        return CreatedAtRoute("DefaultApi", new { id = store.id }, store);
    //    }

    //    // DELETE: api/Stores/5
    //    [ResponseType(typeof(Store))]
    //    public async Task<IHttpActionResult> DeleteStore(int id)
    //    {
    //        Store store = this.repository.Single(id);
    //        if (store == null)
    //        {
    //            return NotFound();
    //        }

    //        this.repository.Delete(store);

    //        return Ok(store);
    //    }

    //    private bool StoreExists(int id)
    //    {
    //        var store = this.repository.Single(id);
    //        return store == null ? false : true;
    //    }

    //    #endregion
    //}
}