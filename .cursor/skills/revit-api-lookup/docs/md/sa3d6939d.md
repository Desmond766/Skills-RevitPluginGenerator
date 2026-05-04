---
kind: method
id: M:Autodesk.Revit.DB.AssemblyInstance.AddMemberIds(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/cd0c727f-218c-a506-b0b5-4550ca6741bf.htm
---
# Autodesk.Revit.DB.AssemblyInstance.AddMemberIds Method

Adds member element ids for the assembly instance.

## Syntax (C#)
```csharp
public void AddMemberIds(
	ICollection<ElementId> memberIds
)
```

## Parameters
- **memberIds** (`System.Collections.Generic.ICollection < ElementId >`) - Element ids to be added to the assembly instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more element ids was not permitted for membership in the assembly instance.
 Elements should be of a valid category and should not be a member of an existing assembly.
 -or-
 The provided set includes one or more element ids that cannot be added to or removed from the assembly on their own.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

