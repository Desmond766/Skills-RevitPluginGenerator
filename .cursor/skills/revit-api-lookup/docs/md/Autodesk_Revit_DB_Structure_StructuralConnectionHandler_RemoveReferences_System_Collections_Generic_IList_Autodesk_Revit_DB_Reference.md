---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionHandler.RemoveReferences(System.Collections.Generic.IList{Autodesk.Revit.DB.Reference})
source: html/aded3846-21ad-e351-5c2a-c7bbfe1b0682.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionHandler.RemoveReferences Method

Removes references from the connection.
 All references in an array should belong to the connection.

## Syntax (C#)
```csharp
public void RemoveReferences(
	IList<Reference> picks
)
```

## Parameters
- **picks** (`System.Collections.Generic.IList < Reference >`) - The array containing picks to be removed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more picks was not permitted to be removed from the connection.
 Picks should be members of the connection.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

