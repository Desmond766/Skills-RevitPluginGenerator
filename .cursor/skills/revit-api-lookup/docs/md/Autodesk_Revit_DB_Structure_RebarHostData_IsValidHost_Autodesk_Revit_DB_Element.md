---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarHostData.IsValidHost(Autodesk.Revit.DB.Element)
source: html/0d6cf4c6-6f5c-9f21-a6ee-0c15f4cbaabf.htm
---
# Autodesk.Revit.DB.Structure.RebarHostData.IsValidHost Method

Identifies whether a given element can host reinforcement.

## Syntax (C#)
```csharp
public static bool IsValidHost(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element to check.

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

