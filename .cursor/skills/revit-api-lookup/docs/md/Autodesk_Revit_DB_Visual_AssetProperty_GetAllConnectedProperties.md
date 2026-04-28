---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetProperty.GetAllConnectedProperties
source: html/5f34b9bc-4e1b-a9db-5262-327fc22e10c1.htm
---
# Autodesk.Revit.DB.Visual.AssetProperty.GetAllConnectedProperties Method

Gets the list of the connected properties.
 Connected properties are the detachable properties of an AssetProperty.
 e.g. diffuse property can have texture as its connected property. It can also detach texture on runtime.

## Syntax (C#)
```csharp
public IList<AssetProperty> GetAllConnectedProperties()
```

## Returns
A list of the connected properties.

