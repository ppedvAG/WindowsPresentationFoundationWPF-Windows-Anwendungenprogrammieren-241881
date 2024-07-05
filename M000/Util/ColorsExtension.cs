using System.Reflection;
using System.Windows.Markup;
using System.Windows.Media;

namespace M000.Util;

public class ColorsExtension : MarkupExtension
{
    /// <summary>
    /// <ObjectDataProvider x:Key="Odp_Colors" MethodName="GetType" ObjectType="{x:Type sys:Type}">
    ///		<ObjectDataProvider.MethodParameters>
    ///			<sys:String>
    ///				System.Windows.Media.Colors, PresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
    ///			</sys:String>
    ///		</ObjectDataProvider.MethodParameters>
    ///	</ObjectDataProvider>
    ///
    ///	<ObjectDataProvider x:Key="Odp_ColorsProperties" MethodName="GetProperties"	ObjectInstance="{StaticResource Odp_Colors}"/>
    ///	
    /// Erklärung: Von der Colors Klasse wird der Typ geholt, aus dem Typen werden alle Properties entnommen
    /// </summary>
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        PropertyInfo[] properties = typeof(Colors).GetProperties();
        //List<Color> colors = new List<Color>();
        List<NamedColor> colors = new List<NamedColor>();
        foreach (PropertyInfo property in properties)
        {
            //colors.Add((Color) property.GetValue(null));
            colors.Add(new NamedColor((Color)property.GetValue(null), property.Name));
        }
        return colors;
    }
}

public class NamedColor
{
    public Color Color { get; set; }

    public string Name { get; set; }

    public SolidColorBrush Brush
    {
        get
        {
            return new SolidColorBrush(Color);
        }
    }

    public NamedColor(Color color, string name)
    {
        Color = color;
        Name = name;
    }
}