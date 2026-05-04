---
kind: method
id: M:Autodesk.Revit.DB.AssemblyInstance.RemoveMemberIds(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/b7c2e124-12cb-ec24-69b1-afc75ddd199e.htm
---
# Autodesk.Revit.DB.AssemblyInstance.RemoveMemberIds Method

Removes member element ids from the assembly instance.

## Syntax (C#)
```csharp
public void RemoveMemberIds(
	ICollection<ElementId> memberIds
)
```

## Parameters
- **memberIds** (`System.Collections.Generic.ICollection < ElementId >`) - Element ids to be removed from the assembly instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more element ids was not permitted to be removed from the assembly instance.
 Provided set should not be empty and all elements should be a member of the assembly instance.
 -or-
 The provided set includes one or more element ids that cannot be added to or removed from the assembly on their own.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

