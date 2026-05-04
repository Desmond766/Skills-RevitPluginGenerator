---
kind: type
id: T:Autodesk.Revit.DB.Visual.AppearanceAssetEditScope
source: html/743c74ba-12de-4d77-a677-325229525955.htm
---
# Autodesk.Revit.DB.Visual.AppearanceAssetEditScope

A scope object that provides special access and limitations related to editing appearance assets and their related elements.

## Syntax (C#)
```csharp
public class AppearanceAssetEditScope : IDisposable
```

## Remarks
You can use an AppearanceAssetEditScope to modify the values of the properties of appearance assets and connected assets (such as bitmaps). The following restrictions apply:
 A single edit scope is allowed only to edit one top level rendering assets (and its connected assets). To edit more than one appearance asset you must start a different edit scope. An edit scope may be reused for editing another asset, so long as it has been committed or canceled before using start to associate it to a new asset. Multiple changes to the asset are allowed before commit. A transaction must be started before using Commit() on the edited asset. The transaction may be opened before or after the edit scope is started, but must be open to allow the changes into the model.

