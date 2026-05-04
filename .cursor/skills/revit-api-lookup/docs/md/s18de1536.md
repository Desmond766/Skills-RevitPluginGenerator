---
kind: method
id: M:Autodesk.Revit.DB.FamilyUtils.ConvertFamilyToFaceHostBased(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/a834b134-c57e-c062-a044-3b5f677537c0.htm
---
# Autodesk.Revit.DB.FamilyUtils.ConvertFamilyToFaceHostBased Method

Converts a family to be face host based.

## Syntax (C#)
```csharp
public static void ConvertFamilyToFaceHostBased(
	Document document,
	ElementId familyId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the family to be converted.
- **familyId** (`Autodesk.Revit.DB.ElementId`) - The family id.

## Remarks
Converts a family hosted by some element other than a face to be hosted by a face. This is done by replacing the existing host (wall, roof, ceiling, floor) with a face.
 Conversion can succeed only if FamilyUtils.FamilyCanConvertToFaceHostBased() returns true.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input familyId cannot be converted to face host based.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to convert the family to face host based.
 -or-
 The family is already unhosted.

