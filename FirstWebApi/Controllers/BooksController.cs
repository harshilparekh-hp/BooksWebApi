using AutoMapper;
using FirstWebApi.Model;
using FirstWebApi.Model.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        LibraryManagementContext libraryManagementContext = new LibraryManagementContext();
        
        private readonly IMapper _mapper;

        public BooksController(IMapper mapper) => _mapper = mapper; 
        

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var listBooks = await libraryManagementContext.Books.ToListAsync();

            List<BookDTO> books = _mapper.Map<List<BookDTO>>(listBooks);

            return Ok(books);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetBooksById(int Id)
        {
            Book book = await libraryManagementContext.Books.FindAsync(Id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBooks(Book bk)
        {
            await libraryManagementContext.Books.AddAsync(bk);
            await libraryManagementContext.SaveChangesAsync();
            return Ok("Book Added Successfully");
        }

        [HttpPut]
        //[Route("UpdateBook")]
        public async Task<IActionResult> UpdateBooks(Book bk)
        {
            libraryManagementContext.Entry(bk).State = EntityState.Modified;
            await libraryManagementContext.SaveChangesAsync();
            return Ok("Book Updated Successfully");
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteBooks(int Id)
        {
            var book = await libraryManagementContext.Books.FindAsync(Id);

            if(book == null)
                return NotFound();

            libraryManagementContext.Entry(book).State = EntityState.Deleted;
            await libraryManagementContext.SaveChangesAsync();
            return Ok("Deleted Successfully");
        }




        
    }
}
