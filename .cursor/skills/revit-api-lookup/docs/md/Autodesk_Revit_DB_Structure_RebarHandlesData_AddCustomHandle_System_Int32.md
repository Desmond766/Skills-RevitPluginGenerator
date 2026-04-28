---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarHandlesData.AddCustomHandle(System.Int32)
source: html/0c4832c2-3a33-4b9f-5bc4-88f9ea3abce6.htm
---
# Autodesk.Revit.DB.Structure.RebarHandlesData.AddCustomHandle Method

Adds a new handle definition to the rebar. This information is set to the rebar after the API execution is finished successfully.

## Syntax (C#)
```csharp
public void AddCustomHandle(
	int customHandleTag
)
```

## Parameters
- **customHandleTag** (`System.Int32`) - The tag of the handle. The tag should be different from the previous ones that were added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - customHandleTag is a duplicate tag.

