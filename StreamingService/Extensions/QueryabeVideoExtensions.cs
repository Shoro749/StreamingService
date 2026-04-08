using System;
using System.Linq;
using StreamingService.Models;
using StreamingService.DTO.Enums;

namespace StreamingService.Extensions
{
    public static class QueryabeVideoExtensions
    {
        public static IQueryable<Video> ApplyMediaTypeFilter(this IQueryable<Video> query, string? type)
        {
            if (string.IsNullOrWhiteSpace(type) || type.Equals("All", StringComparison.OrdinalIgnoreCase))
            {
                return query;
            }

            if (Enum.TryParse<VideoType>(type, true, out var parsed))
            {
                var enumName = parsed.ToString();
                return query.Where(v => v.VideoType == enumName);
            }

            var normalized = type.Trim().ToLowerInvariant();
            return query.Where(v => v.VideoType != null && v.VideoType.ToLower() == normalized);
        }
    }
}