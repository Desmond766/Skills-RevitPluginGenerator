---
kind: method
id: M:Autodesk.Revit.DB.MEPSupportUtils.CreateDuctworkStiffener(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Double)
source: html/04bc2c56-b510-c0e7-f035-e39b929e3142.htm
---
# Autodesk.Revit.DB.MEPSupportUtils.CreateDuctworkStiffener Method

Create family based stiffener on the specified fabrication ductwork.

## Syntax (C#)
```csharp
public static FamilyInstance CreateDuctworkStiffener(
	Document document,
	ElementId familySymbolId,
	ElementId hostId,
	double distanceFromHostEnd
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **familySymbolId** (`Autodesk.Revit.DB.ElementId`) - The id of a stiffener FamilySymbol.
- **hostId** (`Autodesk.Revit.DB.ElementId`) - The id of the host ductwork.
- **distanceFromHostEnd** (`System.Double`) - The distance from the host primary end to place the hosted instance. Units are in feet (ft).

## Returns
The new stiffener family instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 familySymbolId is not a valid Element identifier.
 -or-
 hostId is not a valid Element identifier.
 -or-
 Invalid familySymbolId for stiffeners.
 -or-
 Host is not a straight ductwork.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The distance from host primary end is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The profiles of family symbol and host are mismatch.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.
- **Autodesk.Revit.Exceptions.RegenerationFailedException** - Failed to create stiffener due to document regenerate error.

