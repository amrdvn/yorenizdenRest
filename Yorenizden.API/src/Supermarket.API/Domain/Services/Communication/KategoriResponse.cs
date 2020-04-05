using Yorenizden.API.Domain.Models;

namespace Yorenizden.API.Domain.Services.Communication
{
    public class KategoriResponse : BaseResponse<Kategori>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="kategori">Saved category.</param>
        /// <returns>Response.</returns>
        public KategoriResponse(Kategori kategori) : base(kategori)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public KategoriResponse(string message) : base(message)
        { }
    }
}