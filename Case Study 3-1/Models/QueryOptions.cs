using System.Linq.Expressions;

namespace Case_Study_3_1.Models
{
    public class QueryOptions<T>
    {
        public Expression<Func<T, Object>> OrderBy { get; set; }
        public Expression<Func<T, bool>> Where { get; set; }
        private string[] includes = Array.Empty<string>();
        public string Includes { set => includes = value.Replace(" ", "").Split(','); }
        public string[] GetIncludes() => includes;
        public bool HasWhere => Where != null;
        public bool HasOrderBy => OrderBy != null;
    }
}
