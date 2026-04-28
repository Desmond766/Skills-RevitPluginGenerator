---
kind: method
id: M:Autodesk.Revit.DB.InstanceVoidCutUtils.IsVoidInstanceCuttingElement(Autodesk.Revit.DB.Element)
source: html/dc97f4ae-929c-c1ee-63ae-9000362a3047.htm
---
# Autodesk.Revit.DB.InstanceVoidCutUtils.IsVoidInstanceCuttingElement Method

Indicates if the element is a family instance with unattached voids that can cut other elements.

## Syntax (C#)
```csharp
public static bool IsVoidInstanceCuttingElement(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The cutting family instance

## Returns
Returns true if the element is a family instance with unattached voids that can cut other elements.

## Remarks
A family instance can cut if the family has unattached voids and the family's parameter
 "Cut with Voids When Loaded" is checked.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

