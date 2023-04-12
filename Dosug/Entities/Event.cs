namespace Dosug.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.IO;
    using System.Windows.Media.Imaging;

    [Table("Event")]
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            UserEvent = new HashSet<UserEvent>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int DirectionId { get; set; }

        public DateTime StartDateTime { get; set; }

        public int LengthInMinute { get; set; }

        public byte[] Image { get; set; }

        private BitmapImage? _bitmap;
        public BitmapImage? Bitmap
        {
            get
            {
                if (_bitmap == null && Image != null)
                {
                    _bitmap = new BitmapImage();
                    _bitmap.BeginInit();
                    _bitmap.StreamSource = new MemoryStream(Image);
                    _bitmap.EndInit();
                }

                return _bitmap;
            }
        }

        public virtual Direction Direction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserEvent> UserEvent { get; set; }
    }
}
