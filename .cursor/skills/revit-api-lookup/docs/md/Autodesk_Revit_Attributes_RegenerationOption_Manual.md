---
kind: enumMember
id: F:Autodesk.Revit.Attributes.RegenerationOption.Manual
enum: Autodesk.Revit.Attributes.RegenerationOption
source: html/26239bbb-d639-d306-cc43-cc2ec975b822.htm
---
# Autodesk.Revit.Attributes.RegenerationOption.Manual

The API framework will not regenerate after every model level change. Instead, you may use the regeneration APIs to force 
update of the document after a group of changes. SuspendUpdating blocks are unnecessary and should not be used. Performance of 
multiple modifications of the Revit document should be faster than RegenerationOption.Automatic. Because this mode suspends all 
updates to the document, your application should not read data from the document after it has been modified until the document 
has been regenerated, or it runs the risk of accessing stale data. This mode will be only option in a future release.

