---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheet.GetBendProfileWithFillets
source: html/aaae8dee-8b2e-0c57-fa52-adbfb0390581.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.GetBendProfileWithFillets Method

Returns the profile with generated fillets that defines the shape of the Fabric Sheet bending.

## Syntax (C#)
```csharp
public CurveLoop GetBendProfileWithFillets()
```

## Returns
The bend profile with generated fillets that defines the shape of the fabric sheet bending for bent fabric sheet,
 for flat fabric sheet Nothing nullptr a null reference ( Nothing in Visual Basic) will be returned.

## Remarks
Returned curve loop is created automatically as a result of adding fillets to bend profile.
 The returned profile defines the center-curve of a wire.
 Note that bent Fabric Sheets can have planar geometry, but flat Fabric Sheets are always planar.

