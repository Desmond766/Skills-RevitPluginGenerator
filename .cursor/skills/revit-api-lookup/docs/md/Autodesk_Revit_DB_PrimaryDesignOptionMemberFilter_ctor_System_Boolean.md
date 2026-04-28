---
kind: method
id: M:Autodesk.Revit.DB.PrimaryDesignOptionMemberFilter.#ctor(System.Boolean)
source: html/2dbe7246-8abb-9893-f97a-c24189b284af.htm
---
# Autodesk.Revit.DB.PrimaryDesignOptionMemberFilter.#ctor Method

Constructs a new instance of a filter to match elements contained in any primary design option of any design option set, with the option to invert the filter
 and find elements not contained in any primary design option of any design option set.

## Syntax (C#)
```csharp
public PrimaryDesignOptionMemberFilter(
	bool inverted
)
```

## Parameters
- **inverted** (`System.Boolean`) - True if the filter should match all elements which are not contained within a particular design option.

