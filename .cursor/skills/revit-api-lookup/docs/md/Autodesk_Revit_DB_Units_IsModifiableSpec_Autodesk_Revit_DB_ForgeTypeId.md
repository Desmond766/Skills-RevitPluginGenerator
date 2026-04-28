---
kind: method
id: M:Autodesk.Revit.DB.Units.IsModifiableSpec(Autodesk.Revit.DB.ForgeTypeId)
source: html/e897ed5d-9501-4533-4c3b-070ddbf26ab6.htm
---
# Autodesk.Revit.DB.Units.IsModifiableSpec Method

Checks whether the default FormatOptions can be modified for a given spec.

## Syntax (C#)
```csharp
public static bool IsModifiableSpec(
	ForgeTypeId specTypeId
)
```

## Parameters
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the spec to check.

## Returns
True if the FormatOptions can be modified, false otherwise.

## Remarks
The Units class stores a FormatOptions object for every spec, but
 not all of them can be directly modified. Some have fixed
 definitions.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

