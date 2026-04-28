---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheet.GetBendProfile
source: html/537ba6c2-26dd-3ce5-e359-5613eec5ef9b.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.GetBendProfile Method

Returns the profile (not including generated fillets) that defines the shape of the Fabric Sheet bending.

## Syntax (C#)
```csharp
public CurveLoop GetBendProfile()
```

## Returns
The profile that defines the shape of the fabric sheet bending for bent fabric sheet, for flat fabric sheet Nothing nullptr a null reference ( Nothing in Visual Basic) will be returned.

## Remarks
The returned profile defines the center-curve of a wire.
 Note that bent Fabric Sheets can have planar geometry, but flat Fabric Sheets are always planar.

