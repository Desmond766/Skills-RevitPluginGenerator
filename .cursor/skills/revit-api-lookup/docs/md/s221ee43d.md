---
kind: method
id: M:Autodesk.Revit.DB.Reference.Contains(Autodesk.Revit.DB.Reference)
source: html/3635004a-374a-da4e-e843-ec3056c39a0a.htm
---
# Autodesk.Revit.DB.Reference.Contains Method

Checks if given reference identifies part of object identified by this reference.

## Syntax (C#)
```csharp
public bool Contains(
	Reference reference
)
```

## Parameters
- **reference** (`Autodesk.Revit.DB.Reference`) - Another reference.

## Returns
Returns true if given reference identifies part of object identified by this reference, false otherwise.

## Remarks
Can be used to check:
 If given Reference is a part of a particular Subelement identified by this Reference. If given Reference is a part of a particular Element identified by this Reference. 
The input reference can refer to a subelement or a specific geometric item from an element or subelement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .

