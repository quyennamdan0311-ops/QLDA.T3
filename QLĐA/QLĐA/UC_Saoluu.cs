using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace QLĐA
{
    public partial class UC_Saoluu : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qlđatn_final;Integrated Security=True;Encrypt=False";
        private string serverName = "DESKTOP-OREV608\\SQLEXPRESS";
        private string databaseName = "qlđatn_final";

        public UC_Saoluu()
        {
            InitializeComponent();
            this.Load += UC_Saoluu_Load;
        }

        private void UC_Saoluu_Load(object sender, EventArgs e)
        {
            // Thiết lập đường dẫn mặc định
            txtDuongDanLuuFile.ReadOnly = true;
            txtDuongDanLoadFile.ReadOnly = true;

            // Đường dẫn mặc định cho backup
            string defaultBackupPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "QLDA_Backup",
                $"Backup_{databaseName}_{DateTime.Now:yyyyMMdd_HHmmss}.bak"
            );
            txtDuongDanLuuFile.Text = defaultBackupPath;
        }

        // ===== NÚT BROWSE ĐỂ CHỌN NƠI LƯU FILE BACKUP (SAO LƯU) =====
        private void btnBrowseSave_Click(object sender, EventArgs e)
        {
            
        }

        // ===== NÚT BROWSE ĐỂ CHỌN FILE BACKUP ĐỂ PHỤC HỒI =====
        private void btnBrowseLoad_Click(object sender, EventArgs e)
        {
            
        }

        // ===== NÚT SAO LƯU DỮ LIỆU =====
        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDuongDanLuuFile.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn nơi lưu file backup!\n\n" +
                    "Nhấn nút 'Browse' để chọn vị trí lưu file.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn sao lưu cơ sở dữ liệu?\n\n" +
                $"Database: {databaseName}\n" +
                $"Nơi lưu: {txtDuongDanLuuFile.Text}\n\n" +
                $"Quá trình sao lưu có thể mất vài phút.",
                "Xác nhận sao lưu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                BackupDatabase();
            }
        }

        // ===== NÚT PHỤC HỒI DỮ LIỆU =====
        private void btnRestore_Click(object sender, EventArgs e)
        {
            
        }

        // ===== THỰC HIỆN SAO LƯU =====
        private void BackupDatabase()
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                string directory = Path.GetDirectoryName(txtDuongDanLuuFile.Text);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Kiểm tra file đã tồn tại
                if (File.Exists(txtDuongDanLuuFile.Text))
                {
                    DialogResult overwriteResult = MessageBox.Show(
                        $"File đã tồn tại:\n{txtDuongDanLuuFile.Text}\n\n" +
                        "Bạn có muốn ghi đè không?",
                        "Xác nhận ghi đè",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (overwriteResult == DialogResult.No)
                    {
                        return;
                    }
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string backupQuery = $@"
                        BACKUP DATABASE [{databaseName}] 
                        TO DISK = @backupPath 
                        WITH FORMAT, 
                        MEDIANAME = 'SQLServerBackups',
                        NAME = 'Full Backup of {databaseName}';";

                    using (SqlCommand cmd = new SqlCommand(backupQuery, conn))
                    {
                        cmd.CommandTimeout = 300; // 5 phút timeout
                        cmd.Parameters.AddWithValue("@backupPath", txtDuongDanLuuFile.Text);

                        // Hiển thị progress
                        this.Cursor = Cursors.WaitCursor;
                        this.Enabled = false;

                        cmd.ExecuteNonQuery();

                        this.Cursor = Cursors.Default;
                        this.Enabled = true;

                        FileInfo fileInfo = new FileInfo(txtDuongDanLuuFile.Text);

                        MessageBox.Show(
                            $"✓ Sao lưu dữ liệu thành công!\n\n" +
                            $"File backup: {fileInfo.Name}\n" +
                            $"Đường dẫn: {txtDuongDanLuuFile.Text}\n" +
                            $"Kích thước: {FormatFileSize(fileInfo.Length)}\n" +
                            $"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}",
                            "Sao lưu thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Cập nhật đường dẫn cho lần backup tiếp theo
                        string newBackupPath = Path.Combine(
                            directory,
                            $"Backup_{databaseName}_{DateTime.Now:yyyyMMdd_HHmmss}.bak"
                        );
                        txtDuongDanLuuFile.Text = newBackupPath;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                this.Cursor = Cursors.Default;
                this.Enabled = true;

                MessageBox.Show(
                    $"Lỗi SQL khi sao lưu:\n\n{sqlEx.Message}\n\n" +
                    $"Vui lòng kiểm tra:\n" +
                    $"- Quyền truy cập SQL Server\n" +
                    $"- Quyền ghi file vào thư mục đã chọn\n" +
                    $"- Dung lượng ổ đĩa còn đủ không\n" +
                    $"- SQL Server đang chạy",
                    "Lỗi sao lưu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                this.Enabled = true;

                MessageBox.Show(
                    $"Lỗi khi sao lưu:\n\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ===== THỰC HIỆN PHỤC HỒI =====
        private void RestoreDatabase()
        {
            try
            {
                // Connection string tới master database để restore
                string masterConnectionString = $"Data Source={serverName};Initial Catalog=master;Integrated Security=True;Encrypt=False";

                using (SqlConnection conn = new SqlConnection(masterConnectionString))
                {
                    conn.Open();

                    // Hiển thị progress
                    this.Cursor = Cursors.WaitCursor;
                    this.Enabled = false;

                    // Đóng tất cả kết nối tới database
                    string closeConnectionsQuery = $@"
                        ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";

                    using (SqlCommand closeCmd = new SqlCommand(closeConnectionsQuery, conn))
                    {
                        closeCmd.ExecuteNonQuery();
                    }

                    // Restore database
                    string restoreQuery = $@"
                        RESTORE DATABASE [{databaseName}] 
                        FROM DISK = @backupPath 
                        WITH REPLACE, RECOVERY;";

                    using (SqlCommand cmd = new SqlCommand(restoreQuery, conn))
                    {
                        cmd.CommandTimeout = 600; // 10 phút timeout
                        cmd.Parameters.AddWithValue("@backupPath", txtDuongDanLoadFile.Text);

                        cmd.ExecuteNonQuery();
                    }

                    // Đưa database về chế độ MULTI_USER sau khi restore xong
                    string multiUserQuery = $"ALTER DATABASE [{databaseName}] SET MULTI_USER;";
                    using (SqlCommand multiUserCmd = new SqlCommand(multiUserQuery, conn))
                    {
                        multiUserCmd.ExecuteNonQuery();
                    }
                }

                // Reset UI sau khi đã đóng connection
                this.Cursor = Cursors.Default;
                this.Enabled = true;

                MessageBox.Show(
                    $"✓ Phục hồi dữ liệu thành công!\n\n" +
                    $"Database: {databaseName}\n" +
                    $"File backup: {Path.GetFileName(txtDuongDanLoadFile.Text)}\n" +
                    $"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n\n" +
                    $"Ứng dụng sẽ khởi động lại để áp dụng dữ liệu mới.",
                    "Phục hồi thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Xóa đường dẫn load sau khi phục hồi thành công
                txtDuongDanLoadFile.Clear();

                // Đóng form chính và khởi động lại
                Application.Restart();
            }
            catch (SqlException sqlEx)
            {
                this.Cursor = Cursors.Default;
                this.Enabled = true;

                // Cố gắng đưa database về chế độ MULTI_USER
                try
                {
                    string masterConnectionString = $"Data Source={serverName};Initial Catalog=master;Integrated Security=True;Encrypt=False";
                    using (SqlConnection conn = new SqlConnection(masterConnectionString))
                    {
                        conn.Open();
                        string multiUserQuery = $"ALTER DATABASE [{databaseName}] SET MULTI_USER;";
                        using (SqlCommand cmd = new SqlCommand(multiUserQuery, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch { }

                MessageBox.Show(
                    $"Lỗi SQL khi phục hồi:\n\n{sqlEx.Message}\n\n" +
                    $"Vui lòng kiểm tra:\n" +
                    $"- File backup có hợp lệ không\n" +
                    $"- Quyền truy cập SQL Server\n" +
                    $"- Đóng tất cả ứng dụng đang kết nối database\n" +
                    $"- SQL Server đang chạy",
                    "Lỗi phục hồi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                this.Enabled = true;

                MessageBox.Show(
                    $"Lỗi khi phục hồi:\n\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ===== FORMAT KÍCH THƯỚC FILE =====
        private string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }

        private void btnBrowseSave_Click_1(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Backup Files (*.bak)|*.bak|All Files (*.*)|*.*";
                saveDialog.Title = "Chọn nơi lưu file sao lưu";
                saveDialog.FileName = $"Backup_{databaseName}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                saveDialog.DefaultExt = "bak";

                // Đặt thư mục mặc định
                string defaultFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "QLDA_Backup"
                );

                if (!Directory.Exists(defaultFolder))
                {
                    Directory.CreateDirectory(defaultFolder);
                }

                saveDialog.InitialDirectory = defaultFolder;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDuongDanLuuFile.Text = saveDialog.FileName;
                }
            }

        }

        private void btnBrowseLoad_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Backup Files (*.bak)|*.bak|All Files (*.*)|*.*";
                openDialog.Title = "Chọn file backup để phục hồi";
                openDialog.DefaultExt = "bak";
                openDialog.CheckFileExists = true;
                openDialog.CheckPathExists = true;

                // Đặt thư mục mặc định
                string defaultFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "QLDA_Backup"
                );

                if (Directory.Exists(defaultFolder))
                {
                    openDialog.InitialDirectory = defaultFolder;
                }
                else
                {
                    openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDuongDanLoadFile.Text = openDialog.FileName;

                    // Hiển thị thông tin file đã chọn
                    FileInfo fileInfo = new FileInfo(openDialog.FileName);
                    MessageBox.Show(
                        $"Đã chọn file backup:\n\n" +
                        $"Tên file: {fileInfo.Name}\n" +
                        $"Kích thước: {FormatFileSize(fileInfo.Length)}\n" +
                        $"Ngày tạo: {fileInfo.CreationTime:dd/MM/yyyy HH:mm:ss}",
                        "Thông tin file backup",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

        }

        private void btnRestore_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDuongDanLoadFile.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn file backup để phục hồi!\n\n" +
                    "Nhấn nút 'Browse' để chọn file backup.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(txtDuongDanLoadFile.Text))
            {
                MessageBox.Show(
                    "File backup không tồn tại!\n\n" +
                    "Vui lòng kiểm tra lại đường dẫn hoặc chọn file khác.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtDuongDanLoadFile.Clear();
                return;
            }

            DialogResult confirmResult = MessageBox.Show(
                $"⚠ CẢNH BÁO: Phục hồi dữ liệu sẽ GHI ĐÈ toàn bộ dữ liệu hiện tại!\n\n" +
                $"Database: {databaseName}\n" +
                $"File backup: {Path.GetFileName(txtDuongDanLoadFile.Text)}\n" +
                $"Đường dẫn: {txtDuongDanLoadFile.Text}\n\n" +
                $"Tất cả dữ liệu hiện tại sẽ bị thay thế!\n" +
                $"Bạn có chắc chắn muốn tiếp tục?",
                "Xác nhận phục hồi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Xác nhận lần 2 để tránh nhầm lẫn
                DialogResult confirmResult2 = MessageBox.Show(
                    "Xác nhận lần cuối!\n\n" +
                    "Hành động này KHÔNG THỂ HOÀN TÁC!\n\n" +
                    "Tiếp tục phục hồi?",
                    "Xác nhận lần 2",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult2 == DialogResult.Yes)
                {
                    RestoreDatabase();
                }
            }

        }
    }
}
