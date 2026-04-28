---
kind: method
id: M:Autodesk.Revit.DB.DisplacementElement.IsAllowedAsDisplacedElement(Autodesk.Revit.DB.Element)
source: html/4b243f84-5a2c-48de-2e6c-b9b9e3e4ab11.htm
---
# Autodesk.Revit.DB.DisplacementElement.IsAllowedAsDisplacedElement Method

Indicates if the specified element is allowed to be displaced.

## Syntax (C#)
```csharp
public static bool IsAllowedAsDisplacedElement(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - Any element.

## Returns
Returns true if the element is eligible to be assigned to a DisplacementElement.

## Remarks
Exclusions include view specific elements as well as certain categories of elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

