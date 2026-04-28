---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarHostData.IsReferenceContainedByAValidHost(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Reference)
source: html/962297a1-ccdf-80f7-6190-3c208b9d4a7c.htm
---
# Autodesk.Revit.DB.Structure.RebarHostData.IsReferenceContainedByAValidHost Method

Identifies whether an element that contains the given reference can host reinforcement.

## Syntax (C#)
```csharp
public static bool IsReferenceContainedByAValidHost(
	Document doc,
	Reference reference
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - A document.
- **reference** (`Autodesk.Revit.DB.Reference`) - The reference that is part of the element that will be checked.

## Returns
True if the input Element can host reinforcement elements,
 false otherwise.

## Remarks
Many different elements are allowed to host reinforcement,
 for example, beams, walls, columns, or parts.
 Often there are specific restrictions about whether an element
 can host rebar beyond its type or category.
 For example, the material type of the element may determine this.
 Or for parts, the part must have been created from layers
 that have their role set to Structure.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

