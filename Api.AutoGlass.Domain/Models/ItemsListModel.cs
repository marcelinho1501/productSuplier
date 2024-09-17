using Api.AutoGlass.Domain.Services;
using System.Text.Json.Serialization;

namespace Api.AutoGlass.Domain.Models
{
    public abstract class ItemsListModel<TObject>
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("hasNext")]
        public bool HasNext { get; set; }

        [JsonPropertyName("totalItems")]
        public int TotalItems { get; set; }

        public List<TObject> Items { get; set; } = new List<TObject>();

        #region public method
        public bool TryPage(int pageSize, int page)
        {
            Count = Items?.Count ?? 0;
            if (pageSize <= 0 || page <= 0)
            {
                return false;
            }

            if (Count > 0)
            {
                TotalPages = Items.PageTotal(pageSize);
                HasNext = Items.PageHasNext(pageSize, page);
                Items = Items.Page(pageSize, page);
                TotalItems = Items?.Count ?? 0;
                if (TotalItems == 0)
                {
                    return false;
                }
            }
            else if (page > 1)
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
