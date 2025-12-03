using System;
using System.Collections.Generic;
using System.Text;

namespace ArtStore.Domain.ValueObjects
{
    public record Money(decimal Amount, string Currency);
}
