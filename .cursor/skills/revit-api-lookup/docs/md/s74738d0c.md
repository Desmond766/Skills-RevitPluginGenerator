---
kind: method
id: M:Autodesk.Revit.DB.AssemblyInstance.SetMemberIds(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/ae1f25f5-d8c8-ee29-9725-2d3b578da780.htm
---
# Autodesk.Revit.DB.AssemblyInstance.SetMemberIds Method

Sets member element ids for the assembly instance. All existing members are cleared.

## Syntax (C#)
```csharp
public void SetMemberIds(
	ICollection<ElementId> memberIds
)
```

## Parameters
- **memberIds** (`System.Collections.Generic.ICollection < ElementId >`) - Element ids to set for the assembly instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - This method may not be called during dynamic update.

